namespace Error_Tracker_API.v1.Entity
{
    /// <summary>
    /// Represents a single error log entry in the system.
    /// </summary>
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string Severity { get; set; } = "Info";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ApplicationName { get; set; }
    }
}
