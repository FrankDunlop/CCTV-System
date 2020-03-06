using System;

namespace DVR.Logging
{
    public interface ILogger
    {
        void InitLog();
        void AppendToLog(String LogEntry);
        string GetLogEntries(string LogList);
        void ClearLog();
    }
}
