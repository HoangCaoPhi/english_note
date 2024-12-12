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
       
    };

    public static readonly List<string> SupportedContentType = SupportedContainer.SelectMany(x => x.Value.AllowedContentType).ToList();
    public static readonly List<string> SupportedContainerNames = SupportedContainer.Select(x => x.Value.Name).ToList();
}