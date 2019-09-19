using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();
        Thread.Sleep(5000);
        Console.WriteLine($"Hello {name}!");
        Thread.Sleep(5000);
        Console.WriteLine($"See you soon, {name}");
        Console.ReadKey();
    }
}