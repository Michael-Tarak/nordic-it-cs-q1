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
            someErrorList.Add("problem1");
            someErrorList.Add("problem2");
            someErrorList.Add("problem3");
            someErrorList.Add("problem4");
            someErrorList.Add("problem5");
            foreach (var error in someErrorList)
            {
                Console.WriteLine($"{someErrorList.Category}: {error}");
            }
        }
    }
}
