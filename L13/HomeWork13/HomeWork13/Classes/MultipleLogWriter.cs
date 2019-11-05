namespace HomeWork13
{
    class MultipleLogWriter :AbstractLogWriter, ILogWriter
    {
        private ILogWriter[] interfaceLogWriter;
        public MultipleLogWriter(ConsoleLogWriter clw, FileLogWriter flw)
        {
            interfaceLogWriter = new ILogWriter[] { clw, flw };
        }
        public override void LogInfo(string message)
        {
            foreach (var writer in interfaceLogWriter)
            {
                writer.LogInfo(message);
            }
        }
        public override void LogWarning(string message)
        {
            foreach (var writer in interfaceLogWriter)
            {
                writer.LogWarning(message);
            }
        }
        public override void LogError(string message)
        {
            foreach (var writer in interfaceLogWriter)
            {
                writer.LogError(message);
            }
        }
    }
}
