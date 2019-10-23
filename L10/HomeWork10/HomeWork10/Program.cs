using System;

namespace HomeWork10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person();
                while (true)
                {
                    Console.Write($"Введите имя {i + 1}го человека: ");
                    people[i].Name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(people[i].Name))
                    {
                        break;
                    }
                    Console.WriteLine("Некорректный ввод!");
                }
                while (true)
                {
                    Console.Write($"Введите возраст {i + 1}го человека: ");
                    int inputAge;
                    if (int.TryParse(Console.ReadLine(), out inputAge) && inputAge >= 0)
                    {
                        people[i].Age = inputAge;
                        break;
                    }
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            foreach(var person in people)
            {
                Console.WriteLine(person.OutputInfo); 
            }
            Console.ReadKey();
        }
    }
}
