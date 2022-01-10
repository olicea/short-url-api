using Microsoft.AspNetCore.Mvc;
using short_url_api.Models;

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

    [HttpGet("{shortUrl}")]
    public async Task<ActionResult> GetShortUrlAsync(string shortUrl)
    {
        // redirect to right url
        ShortUrl url = await _shortUrlService.GetOriginalUrlsAsync(shortUrl);

        if (url == null)
        {
            return NotFound();
        }

        return Redirect(url.OriginalUrl);
    }

    [HttpPost(Name = "ShortUrl")]
    public async Task<ShortUrl> ShortUrlAsync(ShortUrl shortUrl)
    {
        return await _shortUrlService.CreateShortUrlAsync(shortUrl);
    }

    [HttpDelete()]
    public async Task<ActionResult> DeleteShortUrlAsync(string userId, string shortUrl)
    {
        ShortUrl url = await _shortUrlService.GetOriginalUrlsAsync(shortUrl);

        if (url == null)
        {
            return NotFound();
        }

        // delete short url
        await _shortUrlService.DeleteShortUrlAsync(userId, shortUrl);

        return NoContent();
    }
}
