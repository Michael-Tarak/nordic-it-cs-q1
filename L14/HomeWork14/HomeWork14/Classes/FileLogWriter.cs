using System.IO;
namespace HomeWork14
{
    class FileLogWriter : AbstractLogWriter, ILogWriter
    {
        protected readonly string Path;
        private static FileLogWriter instance;
        private FileLogWriter(string path)
        {
            Path = path;
        }
        public static FileLogWriter GetInstance()
        {
            return instance ?? (instance = new FileLogWriter(path));
        }


    protected override void WriteMessage(string line)
        {
            File.AppendAllText(Path, line);
        }
    }
}