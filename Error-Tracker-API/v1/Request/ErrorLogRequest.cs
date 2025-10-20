namespace Error_Tracker_API.v1.Request
{
    /// <summary>
    /// Request object used when creating a new error log entry.
    /// </summary>
    public class CreateErrorLogRequest
    {
        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string Severity { get; set; } = "Error";
        public string? ApplicationName { get; set; }
    }
    /// <summary>
    /// Request object used to update an existing error log.
    /// </summary>
    public class UpdateErrorLogRequest
    {
        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string Severity { get; set; } = "Error";
        public string? ApplicationName { get; set; }
    }
}
