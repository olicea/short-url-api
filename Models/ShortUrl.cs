public class ShortUrl
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string Url { get; set; }
    public string OriginalUrl { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}
