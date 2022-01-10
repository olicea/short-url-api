namespace short_url_api.Models
{
    public class UrlDoesNotExistException : Exception
    {
        public UrlDoesNotExistException()
        {
        }

        public UrlDoesNotExistException(string message)
            : base(message)
        {
        }

        public UrlDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}