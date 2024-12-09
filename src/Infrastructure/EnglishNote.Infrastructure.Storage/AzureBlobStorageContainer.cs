using EnglishNote.Application.Abtractions.Storage;

namespace EnglishNote.Infrastructure.Storage;
internal static class AzureBlobStorageContainer
{
    public class Config
    {
        public string Name { get; set; }
        public int AllowedFileSizeInMB { get; set; }
        public string[] AllowedContentType { get; set; } = [];
    }

    public const string TempContainerName = "temp";

    public static readonly Dictionary<StorageContainer, Config> SupportedContainer = new()
    {
        [StorageContainer.IMAGE] = new()
        {
            Name = "qt-package-toc",
            AllowedFileSizeInMB = 5,
            AllowedContentType = ["text/html", "application/pdf"]
        },
        [StorageContainer.ATTACHMENT] = new()
        {
            Name = "qt-investor-kyc",
            AllowedFileSizeInMB = 5,
            AllowedContentType = ["image/jpeg", "image/png"]
        }
    };

    public static readonly List<string> SupportedContentType = SupportedContainer.SelectMany(x => x.Value.AllowedContentType).ToList();
    public static readonly List<string> SupportedContainerNames = SupportedContainer.Select(x => x.Value.Name).ToList();
}