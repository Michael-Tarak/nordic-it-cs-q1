namespace HomeWork15
{
    class LogWriterFactory
    {
        private static LogWriterFactory instance;
        private LogWriterFactory()
        {

        }
        public static LogWriterFactory GetInstance() =>
            instance ?? (instance = new LogWriterFactory());
        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter
        {

        }
    }
}
