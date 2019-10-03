using System;

namespace ClassWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            var marks = new[]
            {
                new [] {2,3,3,2,3},
                new [] {2,4,5,3},
                null,
                new [] {5,5,5,5},
                new [] {4}
            };
            var averageMark = new double[marks.Length];
            int i = 0;
            double sumOfWeek = 0;
            for (; i < marks.Length; i++)
            {
                double sumOfDay = 0;
                if (marks[i] == null)
                {
                    Console.WriteLine($"The average mark for day #{i + 1} is: N/A");

                    continue;

                }

                for (int j = 0; j < marks[i].Length; j++)
                {
                    sumOfDay += marks[i][j];
                    averageMark[i] = sumOfDay / marks[i].Length;
                    sumOfWeek += averageMark[i];
                }
                Console.WriteLine($"The average mark for day #{i + 1} is: {averageMark[i]}");
            }
            Console.WriteLine($"The average mark for week is {sumOfWeek/marks.Length}");
        }
    }
}
