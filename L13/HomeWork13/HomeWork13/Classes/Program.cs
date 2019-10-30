using System;

namespace HomeWork13
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = new FileLogWriter("log.txt");
            var consoleLogWriter = new ConsoleLogWriter();
            fileLogWriter.LogInfo("Some info");
            fileLogWriter.LogWarning("warning stuff");
            fileLogWriter.LogWarning("that\'s a wrong numba!");
            consoleLogWriter.LogInfo("Some info");
            consoleLogWriter.LogWarning("warning stuff");
            consoleLogWriter.LogWarning("that\'s a wrong numba!");
            var multiLogWriter = new MultipleLogWriter(consoleLogWriter, fileLogWriter);
            multiLogWriter.LogInfo("Some different info");
            multiLogWriter.LogWarning("warning other stuff");
            multiLogWriter.LogWarning("that\'s a wrong number!");
        }
    }
}
