using System.Security.Cryptography;
using System.Text;

namespace short_url_api.Data;

public class ShortUrlService
{
    public Task<string> CreateShortUrlAsync(string userId, string originalUrl, string shortUrl = "", DateTime? expiration = null)
    {
        // return empty for now
        return Task.FromResult(shortUrl);
    }

    public Task<List<ShortUrl>> GetOriginalUrlsAsync(string shortUrl)
    {
        // return empty for now
        return Task.FromResult(new List<ShortUrl>());
    }

    internal static string CreateShortUrl(string originalUrl)
    {
        // get string encoding
        byte[] bytes = Encoding.UTF8.GetBytes(originalUrl);

        // shorten url here, some hash applied
        SHA256  sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(bytes);
        
        //encode to base64
        var base64 = Convert.ToBase64String(hash);

        //get only the first maxLength characters
        var shortUrl = base64.Substring(0, maxLength);

        return shortUrl;
    }

    internal const int maxLength = 6;
}