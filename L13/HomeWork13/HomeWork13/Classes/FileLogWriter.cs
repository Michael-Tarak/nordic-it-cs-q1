using System;
using System.IO;
namespace HomeWork13
{
    class FileLogWriter : ILogWriter
    {
        protected readonly string _path;
        public FileLogWriter(string path)
        {
            _path = path;
            if (!File.Exists(path))
            {
                FileStream fs =  File.Create(path);
                fs.Close();
            }
        }
        public void LogInfo(string message)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine($"{DateTimeOffset.Now}\tInfo\t{message}");
            }
        }
        public void LogWarning(string message)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine($"{DateTimeOffset.Now}\tWarning\t{message}");
            }
        }
        public void LogError(string message)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine($"{DateTimeOffset.Now}\tError\t{message}");
            }
        }
    }
}
