namespace EnglishNote.Infrastructure.Storage;
public class AzureStorageOptions
{
    public const string SectionName = "AzureBlobStorage";

    public required string ConnectionString { get; set; }

    public int TempContainerSasExpiryInMinutes { get; set; } = 5;

    public int SignedUriExpiryInMinutes { get; set; } = 60;
}