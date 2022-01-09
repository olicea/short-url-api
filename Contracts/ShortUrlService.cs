using System.Security.Cryptography;
using System.Text;

public class ShortUrlService : ISHortUrlService
{
    public Task<ShortUrl> CreateShortUrlAsync(string userId, string originalUrl, string shortUrl = "", DateTime? expirationDate = null)
    {
        //create the short url
        string shortUrlString = CreateShortUrl(originalUrl);

        var url = new ShortUrl()
        {
            Url = shortUrlString,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow + timeToLive,
            OriginalUrl = originalUrl
        };
        //add url to the database
        shortUrls.Add(url);

        return Task.FromResult(url);
    }

    public Task<ShortUrl> GetOriginalUrlsAsync(string shortUrl)
    {
        // lookup the short url from the database
        var url = shortUrls.FirstOrDefault(u => u.Url == shortUrl);

        //fail if it does nto exist
        if (url == null)
        {
            throw new UrlDoesNotExistException("Short url does not exist");
        }

        // return empty for now
        return Task.FromResult(url);
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
    internal readonly TimeSpan timeToLive = TimeSpan.FromDays(90);
    internal List<ShortUrl> shortUrls = new List<ShortUrl>();
}