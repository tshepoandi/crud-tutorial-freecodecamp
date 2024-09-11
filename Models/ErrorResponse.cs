namespace TodoAPI.Models
{
    public class ErrorResponse
    {
        public string Title { get; set; }

        public int statusCode { get; set; }

        public string Message { get; set; }
    }
}
