using System;
namespace HomeWork14
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        private static ConsoleLogWriter instance;
        private ConsoleLogWriter()
        { }
        public static ConsoleLogWriter GetInstance() =>
            instance ?? (instance = new ConsoleLogWriter());
        protected override void WriteMessage(string line)
        {
            Console.WriteLine(line);
        }
    }
}
