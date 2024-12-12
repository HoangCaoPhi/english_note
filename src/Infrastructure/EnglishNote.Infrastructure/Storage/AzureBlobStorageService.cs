using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using EnglishNote.Application.Abtractions.Storage;
using Microsoft.Extensions.Options;
using Shared;

namespace EnglishNote.Infrastructure.Storage;

internal sealed class AzureBlobStorageService(
    BlobServiceClient blobServiceClient,
    IOptions<AzureStorageOptions> azureBlobOptions) : IStorageService
{
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;
    private readonly AzureStorageOptions _azureBlobOptions = azureBlobOptions.Value;

    public async Task<Result> DeleteAsync(string fileName, StorageContainer container, CancellationToken cancellationToken = default)
    {
        var client = GetBlobClient(fileName, container);

        var res = await client.DeleteIfExistsAsync(cancellationToken: cancellationToken);

        return res.Value
            ? Result.Success()
            : Result.Failure(AzureBlobStorageErrors.BlobClientNotExists);
    }

    public async Task<Result<FileResponse>> DownloadAsync(string fileName, StorageContainer container, CancellationToken cancellationToken = default)
    {
        var client = GetBlobClient(fileName, container);

        if (!await client.ExistsAsync(cancellationToken))
            return Result<FileResponse>.Failure(AzureBlobStorageErrors.BlobClientNotExists);

        var response = await client.DownloadContentAsync(cancellationToken: cancellationToken);
        return new FileResponse(response.Value.Content.ToStream(), response.Value.Details.ContentType);
    }

    public async Task<Result> CopyTempToAsync(
        string fileName,
        StorageContainer destContainerName,
        CancellationToken cancellationToken = default)
    {
        var sourceBlob = GetTempBlobClient(fileName);

        var targetConfig = AzureBlobStorageContainer.SupportedContainer.GetValueOrDefault(destContainerName);
        if (targetConfig is null)
            return Result.Failure(AzureBlobStorageErrors.InvalidContainerName);

        var containerClient = _blobServiceClient.GetBlobContainerClient(targetConfig.Name);
        var targetBlob = containerClient.GetBlobClient(fileName);

        if (!await sourceBlob.ExistsAsync(cancellationToken))
            return Result<BlobClient>.Failure(AzureBlobStorageErrors.BlobClientNotExists);

        var properties = await sourceBlob.GetPropertiesAsync(cancellationToken: cancellationToken);

        var contentType = properties.Value.ContentType;
        var fileSize = properties.Value.ContentLength;

        if (!targetConfig.AllowedContentType.Contains(contentType))
            return Result.Failure(AzureBlobStorageErrors.InvalidContentType);

        if (fileSize > targetConfig.AllowedFileSizeInMB * 1048576)
            return Result.Failure(AzureBlobStorageErrors.ExceedLimitFileSize);

        var copyOperation = await targetBlob.StartCopyFromUriAsync(
            sourceBlob.Uri,
            cancellationToken: cancellationToken);

        await copyOperation.WaitForCompletionAsync(cancellationToken);

        return Result.Success();
    }

    public Result<Uri> GenerateSasUriTempContainer()
    {
        var fileName = Guid.CreateVersion7().ToString();

        var client = GetTempBlobClient(fileName);

        if (!client.CanGenerateSasUri)
            return Result<Uri>.Failure(AzureBlobStorageErrors.InvalidFilePath);

        BlobSasBuilder sasBuilder = new()
        {
            Protocol = SasProtocol.Https,
            BlobContainerName = AzureBlobStorageContainer.TempContainerName,
            Resource = "b",
            StartsOn = DateTimeOffset.UtcNow.AddSeconds(-10),
            ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(_azureBlobOptions.TempContainerSasExpiryInMinutes),
        };

        sasBuilder.SetPermissions(BlobContainerSasPermissions.Write);

        return client.GenerateSasUri(sasBuilder);
    }

    public Result<Uri> GetSignedUri(string fileName, StorageContainer container, bool isDownload = true)
    {
        var client = GetBlobClient(fileName, container);

        if (!client.CanGenerateSasUri)
            return Result<Uri>.Failure(AzureBlobStorageErrors.InvalidFilePath);

        BlobSasBuilder sasBuilder = new()
        {
            BlobContainerName = client.GetParentBlobContainerClient().Name,
            BlobName = client.Name,
            Resource = "b",
            StartsOn = DateTimeOffset.UtcNow.AddSeconds(-10),
            ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(_azureBlobOptions.SignedUriExpiryInMinutes),
            ContentDisposition = isDownload ? $"attachment; filename=\"{fileName}\"" : "inline",
        };

        sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);

        return client.GenerateSasUri(sasBuilder);
    }

    private BlobClient GetBlobClient(string fileName, StorageContainer container)
    {
        var config = AzureBlobStorageContainer.SupportedContainer.GetValueOrDefault(container) ?? throw new InvalidOperationException("Invalid container name");
        var containerClient = _blobServiceClient.GetBlobContainerClient(config.Name);

        return containerClient.GetBlobClient(fileName);
    }

    private BlobClient GetTempBlobClient(string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(AzureBlobStorageContainer.TempContainerName);

        return containerClient.GetBlobClient(fileName);
    }
}