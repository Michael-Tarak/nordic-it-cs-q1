using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassWork9
{
    class Program
    {
        static void Main(string[] args)
        {
            var massive = new int[10000];
            for (int i = 0; i < massive.Length; i++)
            {
                var randomizer = (new Random().Next(0,1000));
                massive[i] = randomizer;
            }
            var massive2 = new int[massive.Length];
            for (int i = 0; i < massive2.Length; i++)
            {
                massive2[i] = massive[i];
            }
            Stopwatch timer1 = new Stopwatch();
            timer1.Start();
            Array.Sort(massive);
            timer1.Stop();
            TimeSpan ts1 = timer1.Elapsed;
            Console.WriteLine(ts1);
            Stopwatch timer2 = new Stopwatch();
            timer1.Start();
            BubbleSort(massive2);
            timer2.Stop();
            TimeSpan ts2 = timer2.Elapsed; 
            Console.WriteLine(ts2);
        }
        static void BubbleSort(int [] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var limit = array.Length - 1 - i;
                for (int j = 0; j < limit; j++)
                {
                    if(array[j] > array[j+1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
