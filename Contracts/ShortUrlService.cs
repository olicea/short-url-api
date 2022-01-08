namespace short_url_api.Data;

public class ShortUrlService
{
    public Task<string> ShortUrlAsync(string userId, string originalUrl, string shortUrl = "", DateTime? expiration = null)
    {
        // return empty for now
        return Task.FromResult(shortUrl);
    }

    public Task<List<ShortUrl>> GetOriginalUrlsAsync(string userId)
    {
        // return empty for now
        return Task.FromResult(new List<ShortUrl>())
        ;
    }

    internal static string ShortUrl(string originalUrl)
    {
        // shorten url here, some hash applied
        return originalUrl;
    }
}