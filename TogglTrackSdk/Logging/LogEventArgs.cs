namespace TogglSdk.Logging;

public class LogEventArgs
{
    public enum LogLevel
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal,
    }

    public LogEventArgs(LogLevel level, string message) { Level = level; Message = message; }
    public string Message { get; }
    public LogLevel Level { get; }
}
