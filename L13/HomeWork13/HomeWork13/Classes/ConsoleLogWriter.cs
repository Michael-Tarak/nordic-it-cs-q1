using System;
namespace HomeWork13
{
    class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        protected override void WriteMessage(string line)
        {
            Console.WriteLine(line);
        }
    }
}
