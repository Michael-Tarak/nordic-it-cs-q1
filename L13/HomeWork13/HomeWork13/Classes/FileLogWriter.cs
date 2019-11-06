using System.IO;
namespace HomeWork13
{
    class FileLogWriter : AbstractLogWriter, ILogWriter
    {
        protected readonly string _path;
        public FileLogWriter(string path)
        {
            _path = path;
        }

        protected override void WriteMessage(string line)
        {
            File.AppendAllText(_path, line);
        }
    }
}