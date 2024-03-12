using System.Diagnostics;

namespace FlyApp.Log;

public class EventLogger
{
    private readonly string _sourceName;

    public EventLogger(string sourceName)
    {
        _sourceName = sourceName;
    }

    public void LogInformation(string message)
    {
        LogEvent(message, EventLogEntryType.Information);
    }

    public void LogWarning(string message)
    {
        LogEvent(message, EventLogEntryType.Warning);
    }

    public void LogError(string message)
    {
        LogEvent(message, EventLogEntryType.Error);
    }

    private void LogEvent(string message, EventLogEntryType entryType)
    {
        if (!EventLog.SourceExists(_sourceName))
        {
            EventLog.CreateEventSource(_sourceName, _sourceName);
        }

        using var eventLog = new EventLog(_sourceName);
        eventLog.Source = _sourceName;
        eventLog.WriteEntry(message, entryType);
    }
}