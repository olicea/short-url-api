using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using short_url_api.Controllers;
using short_url_api.Models;

namespace short_url_api.Tests;

public class ShortUrlControllerTests
{
    [Fact]
    public async void CanAddShortUrlsAsync()
    {
        // Arrange
        var mockService = new Mock<ISHortUrlService>();
        var mockLogger = new Mock<ILogger<ShortUrlController>>();
        var controller = new ShortUrlController(mockLogger.Object, mockService.Object);

        var url = new ShortUrl()
        {
            OriginalUrl = "https://www.github.com/olicea",
            UserId = "1"
        };


        // Act
        var result = await controller.ShortUrlAsync(url);

        // Assert
        //var viewResult = Assert.IsType<ShortUrl>(result);
        mockService.Verify(v => v.CreateShortUrlAsync(It.IsAny<ShortUrl>()), Times.Once);
    }
}