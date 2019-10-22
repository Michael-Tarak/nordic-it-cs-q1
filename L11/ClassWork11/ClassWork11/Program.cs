using System;

namespace ClassWork11
{
    class Program
    {
        static void Main(string[] args)
        {
            var pet1 = new Pet()
            {
                Name = "Alex",
                Kind = "Lion",
                Sex = 'M',
                Age = 20
            };
            Console.WriteLine(pet1.Description);
            var pet2 = new Pet()
            {
                Name = "Morty",
                Kind = "Zebra",
                Sex = 'M',
                Age = 19
            };
            Console.WriteLine(pet2.Description);
            Console.ReadKey();
        }
    }
}
