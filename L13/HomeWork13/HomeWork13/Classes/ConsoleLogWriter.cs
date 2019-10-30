using System;
namespace HomeWork13
{
    class ConsoleLogWriter : AbstractLogWriter,ILogWriter
    {
        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            Console.WriteLine(WriterOutput);
        }
        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            Console.WriteLine(WriterOutput);
        }
        public override void LogError(string message)
        {
            base.LogError(message);
            Console.WriteLine(WriterOutput);
        }

    }
}
