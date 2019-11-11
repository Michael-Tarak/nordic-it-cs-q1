using System;
namespace HomeWork15
{
    class LogWriterFactory
    {
        private static LogWriterFactory instance;
        private LogWriterFactory()
        {}
        public static LogWriterFactory GetInstance() =>
            instance ?? (instance = new LogWriterFactory());
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
                    throw new InvalidOperationException();
                }
                return new FileLogWriter((string)parameters);
            }
            else if(typeof(T) == typeof(MultipleLogWriter))
            {
                
                return new MultipleLogWriter((ILogWriter)parameters);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
