using System;

namespace HomeWork14
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = FileLogWriter.GetInstance("log.txt");
            var consoleLogWriter = ConsoleLogWriter.GetInstance();
            fileLogWriter.LogInfo("Some info");
            fileLogWriter.LogWarning("warning stuff");
            fileLogWriter.LogError("that\'s a wrong numba!");
            consoleLogWriter.LogInfo("Some info");
            consoleLogWriter.LogWarning("warning stuff");
            consoleLogWriter.LogError("that\'s a wrong numba!");
            var multiLogWriter = MultipleLogWriter.GetInstance(consoleLogWriter, fileLogWriter);
            multiLogWriter.LogInfo("Some different info");
            multiLogWriter.LogWarning("warning other stuff");
            multiLogWriter.LogError("that\'s a wrong number!");
        }
    }
}
