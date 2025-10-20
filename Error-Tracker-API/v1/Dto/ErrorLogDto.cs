namespace Error_Tracker_API.v1.Dto
{
    /// <summary>
    /// Data Transfer Object for returning error log data.
    /// </summary>
    public class ErrorLogDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string Severity { get; set; } = string.Empty;
        public string? ApplicationName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
