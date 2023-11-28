using TogglSdk.Logging;

namespace ToggSdk.Logging;

internal class LogManager
{
    private static readonly LogManager instance = new LogManager();
    public static LogManager Instance => instance;

    private LogManager() { }

    public delegate void LogEventHandler(object sender, LogEventArgs e);

    public event LogEventHandler LogEvent;

    internal virtual void Trace(string message) => Log(LogEventArgs.LogLevel.Trace, message);
    internal virtual void Debug(string message) => Log(LogEventArgs.LogLevel.Debug, message);
    internal virtual void Info(string message) => Log(LogEventArgs.LogLevel.Info, message);
    internal virtual void Warn(string message) => Log(LogEventArgs.LogLevel.Warn, message);
    internal virtual void Error(string message) => Log(LogEventArgs.LogLevel.Error, message);
    internal virtual void Fatal(string message) => Log(LogEventArgs.LogLevel.Fatal, message);

    internal virtual void Log(LogEventArgs.LogLevel level, string message)
    {
        LogEvent?.Invoke(this, new LogEventArgs(level, message));
    }
}
