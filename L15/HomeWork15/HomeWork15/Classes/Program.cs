using System;

namespace HomeWork15
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = new FileLogWriter("log.txt");
            var consoleLogWriter = new ConsoleLogWriter();
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
