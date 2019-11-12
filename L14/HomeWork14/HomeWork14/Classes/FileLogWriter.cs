using System.IO;
namespace HomeWork14
{
    class FileLogWriter : AbstractLogWriter, ILogWriter
    {
        public string Path = "log.txt";
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
            File.AppendAllText(Path, line);
        }
    }
}