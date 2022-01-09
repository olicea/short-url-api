public interface ISHortUrlService
{
    Task<ShortUrl> CreateShortUrlAsync(string userId, string originalUrl, string shortUrl, DateTime? expirationDate);
    Task<ShortUrl> CreateShortUrlAsync(ShortUrl url) => CreateShortUrlAsync(url.UserId, url.OriginalUrl, url.Url, url.ExpirationDate);
    Task<ShortUrl> GetOriginalUrlsAsync(string shortUrl);
}