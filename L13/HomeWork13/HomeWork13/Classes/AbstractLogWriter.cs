using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork13
{
    abstract class AbstractLogWriter :ILogWriter
    {
        protected  string LogOutput(string typeOfLog, string message)
        {
            return $"{DateTimeOffset.Now}\t{typeOfLog}\t{message}";
        }
        public abstract void LogInfo(string message);
        public abstract void LogWarning(string message);
        public abstract void LogError(string message);
    }
}
