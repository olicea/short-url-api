using Microsoft.AspNetCore.Mvc;

namespace short_url_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShortUrlController : ControllerBase
{
    private readonly ILogger<ShortUrlController> _logger;
    private readonly ISHortUrlService _shortUrlService;

    public ShortUrlController(ILogger<ShortUrlController> logger, ISHortUrlService shortUrlService)
    {
        _logger = logger;
        _shortUrlService = shortUrlService;
    }

    // [HttpGet()]
    // public async Task<ActionResult> GetAsync(string shortUrl)
    // {
    //     // redirect to right url
    //     ShortUrl url = await _shortUrlService.GetOriginalUrlsAsync(shortUrl);
    //     return Redirect(url.OriginalUrl);
    // }

    [HttpGet(Name = "GetUrl")]
    public ShortUrl Get(string userId, string shortUrl)
    {
        return new ShortUrl() { Url = "test", ExpirationDate = DateTime.Now, OriginalUrl = "test" };
        //_shortUrlService.GetOriginalUrlsAsync(shortUrl);
    }

    // [HttpPost(Name = "ShortUrl")]
    // public async Task<ShortUrl> ShortUrlAsync(string userId, string originalUrl, string shortUrl = null, DateTime? expirationDate = null)
    // {
    //     return await _shortUrlService.CreateShortUrlAsync(userId, originalUrl, shortUrl, expirationDate);
   // }

    [HttpPost(Name = "ShortUrl")]
    public async Task<ShortUrl> ShortUrlAsync(ShortUrl shortUrl)
    {
        return await _shortUrlService.CreateShortUrlAsync(shortUrl);
    }
}
