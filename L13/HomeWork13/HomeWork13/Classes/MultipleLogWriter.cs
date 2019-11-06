namespace HomeWork13
{
    class MultipleLogWriter : ILogWriter
    {
        private ILogWriter[] _multipleLogWriter;
        public MultipleLogWriter(params ILogWriter[] writer)
        {
            _multipleLogWriter = writer;
        }
        public void LogInfo(string message)
        {
            foreach (var writer in _multipleLogWriter)
            {
                writer.LogInfo(message);
            }
        }
        public void LogWarning(string message)
        {
            foreach (var writer in _multipleLogWriter)
            {
                writer.LogWarning(message);
            }
        }
        public void LogError(string message)
        {
            foreach (var writer in _multipleLogWriter)
            {
                writer.LogError(message);
            }
        }
    }
}
