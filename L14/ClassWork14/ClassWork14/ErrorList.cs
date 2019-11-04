using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassWork14
{
    class ErrorList : IDisposable, IEnumerable<string>
    {
        public string Category { get; }
        private List  <string> errorListCount;
        public ErrorList(string category, List<string> list)
        {
            Category = category;
            errorListCount = list;
        }
        public void Add(string errorMessage)
        {
            errorListCount.Add(errorMessage);
        }
        public void Dispose()
        {
            if(errorListCount!=null)
            {
                errorListCount.Clear();
                errorListCount = null;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return errorListCount.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
