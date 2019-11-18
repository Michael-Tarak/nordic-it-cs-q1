using System;
namespace HomeWork15
{
    class LogWriterFactory
    {
        private static LogWriterFactory _instance;
        public static LogWriterFactory Instance
        {
            get =>
                _instance ?? (_instance = new LogWriterFactory());
        }
        private LogWriterFactory()
        {}
        public ILogWriter GetLogWriter<T>(object parameters = null) where T : ILogWriter
        {
            if(typeof(T) == typeof(ConsoleLogWriter))
            {
                return new ConsoleLogWriter();
            }
            else if(typeof(T) == typeof(FileLogWriter))
            {
                if(parameters == null)
                {
                    throw new ArgumentException();
                }
                return new FileLogWriter((string)parameters);
            }
            else
            {
                if (parameters == null)
                {
                    throw new ArgumentException();
                }
                return new MultipleLogWriter((ILogWriter[])parameters);
            }
        }
    }
}
