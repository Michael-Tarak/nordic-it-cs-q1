using System;

namespace HomeWork14
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = FileLogWriter.Instance;
            var consoleLogWriter = ConsoleLogWriter.Instance;
            fileLogWriter.Path = "newLog.txt";
            fileLogWriter.LogInfo("Some info");
            fileLogWriter.LogWarning("warning stuff");
            fileLogWriter.LogError("that\'s a wrong numba!");
            consoleLogWriter.LogInfo("Some info");
            consoleLogWriter.LogWarning("warning stuff");
            consoleLogWriter.LogError("that\'s a wrong numba!");
            var multiLogWriter = new MultipleLogWriter(consoleLogWriter, fileLogWriter);
            multiLogWriter.LogInfo("Some different info");
            multiLogWriter.LogWarning("warning other stuff");
            multiLogWriter.LogError("that\'s a wrong number!");
        }
    }
}
