namespace EnglishNote.Infrastructure.Cache;

public class CacheOptions
{
    public const string Key = "CacheSettings";
    public Dictionary<string, CacheConfiguration> Sections { get; set; } = [];
}

public class CacheConfiguration
{
    public CacheType CacheType { get; set; }
    public string CacheKey { get; set; }
    public int? SlidingExpiration { get; set; }
    public int AbsoluteExpiration { get; set; }
}

public enum CacheType
{
    Memory = 0,
    Redis = 1
}
