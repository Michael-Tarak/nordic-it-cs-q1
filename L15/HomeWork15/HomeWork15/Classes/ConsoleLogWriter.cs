using System;
namespace HomeWork15
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        protected override void WriteMessage(string line)
        {
            Console.WriteLine(line);
        }
    }
}
