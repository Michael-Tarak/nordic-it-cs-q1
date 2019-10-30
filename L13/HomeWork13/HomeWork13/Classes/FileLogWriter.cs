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
            base.LogInfo(message);
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine(WriterOutput);
            }
        }
        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine(WriterOutput);
            }
        }
        public override void LogError(string message)
        {
            base.LogError(message);
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine(WriterOutput);
            }
        }
    }
}
