using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork13
{
    abstract class AbstractLogWriter :ILogWriter
    {
        protected string WriterOutput { get; set; }
        public virtual  void LogInfo(string message)
        {
            WriterOutput = $"{DateTimeOffset.Now}\tInfo\t{message}";
        }
        public virtual void LogWarning(string message)
        {
            WriterOutput = $"{DateTimeOffset.Now}\tWarning\t{message}";
        }
        public virtual void LogError(string message)
        {
            WriterOutput = $"{DateTimeOffset.Now}\tError\t{message}";
        }


    }
}
