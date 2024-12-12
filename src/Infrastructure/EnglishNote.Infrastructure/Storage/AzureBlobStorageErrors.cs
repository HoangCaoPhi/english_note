using Shared;

namespace EnglishNote.Infrastructure.Storage;
internal class AzureBlobStorageErrors
{
    public static readonly Error BlobClientNotExists = Error.Problem(
        "AzureBlobStorageErrors.BlobClientNotExists",
        "The blob client does not exist.");

    public static readonly Error ExceedLimitFileSize = Error.Problem(
        "AzureBlobStorageErrors.ExceedLimitFileSize",
        "The file exceeds the maximum allowed size. Please reduce the file size and try again.");

    public static readonly Error InvalidContentType = Error.Problem(
        "AzureBlobStorageErrors.InvalidContentType",
        "The content type is not permitted. Please upload a valid file.");

    public static readonly Error InvalidFilePath = Error.Problem(
        "AzureBlobStorageErrors.InvalidFilePath",
        "The file path is invalid. Please provide a valid file path.");

    public static readonly Error InvalidContainerName = Error.Problem(
        "AzureBlobStorageErrors.InvalidContainerName",
        "The container name is invalid. Please provide a valid container name.");
}