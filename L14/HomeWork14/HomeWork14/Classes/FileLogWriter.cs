using System.IO;
namespace HomeWork14
{
    class FileLogWriter : AbstractLogWriter, ILogWriter
    {
        private static string _fileLogPath = "log.txt";
        public static string FileLogPath
        {
            get
            {
                return _fileLogPath;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _fileLogPath = value;
                }
            }
        }
        private static FileLogWriter _instance;
        public static FileLogWriter Instance
        {
            get
            {
                return _instance ?? (_instance = new FileLogWriter());
            }
        }
        private FileLogWriter()
        { }
    protected override void WriteMessage(string line)
        {
            File.AppendAllText(_fileLogPath, line);
        }
    }
}