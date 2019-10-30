using System;
using System.IO;

namespace HomeWork13
{
    class MultipleLogWriter : ILogWriter
    {
        protected readonly string _path;
        public ConsoleLogWriter CLW { get; set; }
        public FileLogWriter FLW { get; set; }
        public MultipleLogWriter(ConsoleLogWriter clw, FileLogWriter flw)
        {
            CLW = clw;
            FLW = flw;
        }
        public void LogInfo(string message)
        {
            CLW.LogInfo(message);
            FLW.LogInfo(message);
        }
        public void LogWarning(string message)
        {
            CLW.LogWarning(message);
            FLW.LogWarning(message);
        }
        public void LogError(string message)
        {
            CLW.LogError(message);
            FLW.LogError(message);
        }

    }
}
