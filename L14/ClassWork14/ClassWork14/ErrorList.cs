using System;
using System.Collections.Generic;

namespace ClassWork14
{
    class ErrorList : IDisposable
    {
        public string Category { get; }
        public List  <string> ErrorListCount;
        public ErrorList(string category, List<string> list)
        {
            Category = category;
            ErrorListCount = list;
        }
        public void Dispose()
        {
            ErrorListCount.Clear();
            ErrorListCount = null;
        }
    }
}
