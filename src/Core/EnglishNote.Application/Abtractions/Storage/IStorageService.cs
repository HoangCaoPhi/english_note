using Shared;

namespace EnglishNote.Application.Abtractions.Storage;
public interface IStorageService
{
    Task<Result> DeleteAsync(string fileName, StorageContainer container, CancellationToken cancellationToken = default);

    Task<Result<FileResponse>> DownloadAsync(string fileName, StorageContainer container, CancellationToken cancellationToken = default);

    Task<Result> CopyTempToAsync(string fileName, StorageContainer destContainerName, CancellationToken cancellationToken = default);

    Result<Uri> GenerateSasUriTempContainer();

    Result<Uri> GetSignedUri(string fileName, StorageContainer container, bool isDownload = false);
}