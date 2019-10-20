using System;

namespace ClassWork10
{
    class Program
    {
        static void Main(string[] args)
        {
            var pet1 = new Pet();
            pet1.Age = 10;
            pet1.Name = "The Cat";
            pet1.Sex = 'F';
            pet1.Kind = "Cat";
            var pet2 = new Pet()
            {
                Name = "The Dog",
                Kind = "Dog",
                Sex = 'M',
                Age = 10
            };
            Console.WriteLine(pet1.Description);
            Console.WriteLine(pet2.Description);

        }
    }
}
