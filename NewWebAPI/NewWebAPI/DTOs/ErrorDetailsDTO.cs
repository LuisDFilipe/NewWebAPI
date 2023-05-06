namespace NewWebAPI.DTOs
{
    public class ErrorDetailsDTO
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public ErrorDetailsDTO(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
