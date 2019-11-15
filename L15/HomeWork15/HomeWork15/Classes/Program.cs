namespace HomeWork15
{
    class Program
    {
        static void Main(string[] args)
        {
            var logWriterFactory = LogWriterFactory.GetInstance();
            var fileLogWriter = logWriterFactory.GetLogWriter<FileLogWriter>("log.txt");
            var consoleLogWriter = logWriterFactory.GetLogWriter<ConsoleLogWriter>();
            fileLogWriter.LogInfo("Some info");
            fileLogWriter.LogWarning("warning stuff");
            fileLogWriter.LogError("that\'s a wrong numba!");
            consoleLogWriter.LogInfo("Some info");
            consoleLogWriter.LogWarning("warning stuff");
            consoleLogWriter.LogError("that\'s a wrong numba!");
            var someLogs = new ILogWriter[]
            {
                consoleLogWriter, fileLogWriter
            };
            var multiLogWriter = logWriterFactory.GetLogWriter<MultipleLogWriter>(someLogs);
            multiLogWriter.LogInfo("Some different info");
            multiLogWriter.LogWarning("warning other stuff");
            multiLogWriter.LogError("that\'s a wrong number!");
        }
    }
}
