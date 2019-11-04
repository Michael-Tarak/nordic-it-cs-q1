using System;
using System.IO;
namespace HomeWork13
{
    class FileLogWriter : AbstractLogWriter, ILogWriter
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
        public override void LogInfo(string message)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine(LogOutput("Info", message));
            }
        }
        public override void LogWarning(string message)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine(LogOutput("Warning", message));
            }
        }
        public override void LogError(string message)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine(LogOutput("Error", message));
            }
        }
    }
}
