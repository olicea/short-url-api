using Microsoft.EntityFrameworkCore;

namespace short_url_api.Models
{
    public class ShortUrlContext : DbContext
    {
        public ShortUrlContext(DbContextOptions<ShortUrlContext> options)
            : base(options)
        {
        }

        public DbSet<ShortUrl> ShortUrls { get; set; } = null!;
    }
}