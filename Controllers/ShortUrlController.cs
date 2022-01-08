using Microsoft.AspNetCore.Mvc;
using short_url_api.Data;

namespace short_url_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShortUrlController : ControllerBase
{
    private readonly ILogger<ShortUrlController> _logger;

    public ShortUrlController(ILogger<ShortUrlController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUrl")]
    public ShortUrl Get(string shortUrl)
    {
        return new ShortUrl() { Url = "test", Expiration = DateTime.Now, OriginalUrl = "test" };
    }


    [HttpPost(Name = "ShortUrl")]
    public string  ShortUrl(string userId, string originalUrl, DateTime expirationTime)
    {
        return ShortUrlService.CreateShortUrl(originalUrl);
    }
}
