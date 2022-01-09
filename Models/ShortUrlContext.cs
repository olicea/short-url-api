using Microsoft.EntityFrameworkCore;

public class ShortUrlContext : DbContext
{
    public ShortUrlContext(DbContextOptions<ShortUrlContext> options)
        : base(options)
    {
    }

    public DbSet<ShortUrl> ShortUrls { get; set; } = null!;
}