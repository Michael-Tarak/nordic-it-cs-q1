using System;
namespace HomeWork14
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        private static ConsoleLogWriter _instance;
        public static ConsoleLogWriter Instance
        {
            get
            {
                return _instance ?? (_instance = new ConsoleLogWriter());
            }
        }
        private ConsoleLogWriter()
        { }
        protected override void WriteMessage(string line)
        {
            Console.WriteLine(line);
        }
    }
}
