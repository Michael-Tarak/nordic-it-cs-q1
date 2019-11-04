using System;
namespace HomeWork13
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        public override void LogInfo(string message)
        {
            Console.WriteLine(LogOutput("Info", message));
        }
        public override void LogWarning(string message)
        {
            Console.WriteLine(LogOutput("Warning", message));
        }
        public override void LogError(string message)
        {
            Console.WriteLine(LogOutput("Error", message));
        }

    }
}
