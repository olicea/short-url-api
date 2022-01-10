using System.Security.Cryptography;
using System.Text;

namespace short_url_api.Models
{
    public class ShortUrlService : ISHortUrlService
    {
        public ShortUrlService(ShortUrlContext context)
        {
            _context = context;
        }

        public async Task<ShortUrl> CreateShortUrlAsync(string userId, string originalUrl, string shortUrl = "", DateTime? expirationDate = null)
        {
            //create the short url
            string shortUrlString = CreateShortUrl(originalUrl);

            var url = new ShortUrl()
            {
                UserId = userId,
                Url = shortUrlString,
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow + _timeToLive,
                OriginalUrl = originalUrl
            };

            //add url to the database context
            _context.ShortUrls.Add(url);
            await _context.SaveChangesAsync();

            return url;
        }

        public Task<ShortUrl> GetOriginalUrlsAsync(string shortUrl)
        {
            // lookup the short url from the database
            var url = _context.ShortUrls.FirstOrDefault(u => u.Url == shortUrl);

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

            //get only the first _maxLength characters
            var shortUrl = base64.Substring(0, _maxLength);

            return shortUrl;
        }

        internal const int _maxLength = 6;
        internal readonly TimeSpan _timeToLive = TimeSpan.FromDays(90);
        internal ShortUrlContext _context;
    }
}