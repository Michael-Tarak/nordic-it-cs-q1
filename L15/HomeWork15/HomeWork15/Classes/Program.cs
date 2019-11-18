namespace HomeWork15
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = LogWriterFactory.Instance.GetLogWriter<FileLogWriter>("log.txt");
            var consoleLogWriter = LogWriterFactory.Instance.GetLogWriter<ConsoleLogWriter>();
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
            var multiLogWriter = LogWriterFactory.Instance.GetLogWriter<MultipleLogWriter>(someLogs);
            multiLogWriter.LogInfo("Some different info");
            multiLogWriter.LogWarning("warning other stuff");
            multiLogWriter.LogError("that\'s a wrong number!");
        }
    }
}
