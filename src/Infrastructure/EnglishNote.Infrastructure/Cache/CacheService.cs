using EnglishNote.Application.Abtractions.Cache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace EnglishNote.Infrastructure.Cache;
public class CacheService(IMemoryCache memoryCache,
                          IOptionsSnapshot<CacheOptions> cacheOptions) : ICacheService
{
    private readonly CacheOptions _cacheOptions = cacheOptions.Value;

    public async Task SetAsync<T>(
        string cacheSection,
        T value,
        Dictionary<string, string>? placeholders = null,
        int? slidingExpirationMinutes = null,
        int? absoluteExpirationMinutes = null)
    {
        if (!_cacheOptions.Sections.TryGetValue(cacheSection, out CacheConfiguration? cacheSettings))
            throw new ArgumentException($"Cache section '{cacheSection}' not found in configuration.", nameof(cacheSection));

        string cacheKey = BuildCacheKey(cacheSection, placeholders);

        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cacheSettings.AbsoluteExpiration)
        };

        if (cacheSettings.SlidingExpiration.HasValue)
        {
            options.SlidingExpiration = TimeSpan.FromMinutes(cacheSettings.SlidingExpiration.Value);
        }

        memoryCache.Set(cacheKey, value, options);

        await Task.CompletedTask;
    }

    public async Task<T?> GetAsync<T>(string cacheSection, Dictionary<string, string>? placeholders = null)
    {
        string cacheKey = BuildCacheKey(cacheSection, placeholders);

        return await Task.FromResult(memoryCache.TryGetValue(cacheKey, out T? value) ? value : default);
    }

    public async Task RemoveAsync(string cacheSection, Dictionary<string, string>? placeholders = null)
    {
        string cacheKey = BuildCacheKey(cacheSection, placeholders);
        memoryCache.Remove(cacheKey);

        await Task.CompletedTask;
    }

    private string BuildCacheKey(string cacheSection, Dictionary<string, string>? placeholders)
    {
        if (!_cacheOptions.Sections.TryGetValue(cacheSection, out CacheConfiguration? cacheSettings))
            throw new ArgumentException($"Cache section '{cacheSection}' not found in configuration.", nameof(cacheSection));

        string cacheKey = cacheSettings.CacheKey;

        if (placeholders != null)
        {
            foreach (var placeholder in placeholders)
            {
                cacheKey = cacheKey.Replace($"{{{placeholder.Key}}}", placeholder.Value, StringComparison.OrdinalIgnoreCase);
            }
        }

        return cacheKey;
    }
}