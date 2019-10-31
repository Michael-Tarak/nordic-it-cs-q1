using System;
using System.Collections.Generic;

namespace ClassWork14
{
    class Program
    {
        static void Main(string[] args)
        {
            var listArray = new List<string>();
            using var someErrorList = new ErrorList("Problems",listArray);
            someErrorList.ErrorListCount.Add("problem1");
            someErrorList.ErrorListCount.Add("problem2");
            someErrorList.ErrorListCount.Add("problem3");
            someErrorList.ErrorListCount.Add("problem4");
            someErrorList.ErrorListCount.Add("problem5");
            for (int i = 0; i < someErrorList.ErrorListCount.Count; i++)
            {
                Console.WriteLine($"{someErrorList.Category}: {someErrorList.ErrorListCount[i]}");
            }
        }
    }
}
