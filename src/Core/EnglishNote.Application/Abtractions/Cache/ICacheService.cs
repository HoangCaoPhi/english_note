namespace EnglishNote.Application.Abtractions.Cache;
public interface ICacheService
{
    Task SetAsync<T>(
        string cacheSection,
        T value,
        Dictionary<string, string>? placeholders = null,
        int? slidingExpirationMinutes = null,
        int? absoluteExpirationMinutes = null);

    Task<T?> GetAsync<T>(string cacheSection, Dictionary<string, string>? placeholders = null);

    Task RemoveAsync(string cacheSection, Dictionary<string, string>? placeholders = null);
}
