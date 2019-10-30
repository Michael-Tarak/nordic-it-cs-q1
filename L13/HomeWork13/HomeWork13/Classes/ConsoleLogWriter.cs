using System;
namespace HomeWork13
{
    class ConsoleLogWriter : ILogWriter
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}\tInfo\t{message}");
        }
        public void LogWarning(string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}\tWarning\t{message}");
        }
        public void LogError(string message)
        {
            Console.WriteLine($"{DateTimeOffset.Now}\tError\t{message}");
        }

    }
}
