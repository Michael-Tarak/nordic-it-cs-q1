using System;

namespace HomeWork15
{
    abstract class AbstractLogWriter :ILogWriter
    {
        protected  string LogOutput(string typeOfLog, string message)
        {
            return $"{DateTimeOffset.Now}\t{typeOfLog}\t{message}";
        }
        protected void LogMessage(string message, string type)
        {
            WriteMessage(LogOutput(message, type));
        }
        public void LogInfo(string message)
        {
            LogMessage(message, "Info");
        }
        public void LogWarning(string message)
        {
            LogMessage(message, "Warning");

        }
        public void LogError(string message)
        {
            LogMessage(message, "Error");
        }
        protected abstract void WriteMessage(string line);
    }
}
