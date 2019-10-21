using System;

namespace HomeWork10
{
    class Person
    {
        private int _age;
        public string Name { get; set; }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if(value >= 0)
                {
                    _age = value;
                }
            }
        }
        public int AgeAfterFourYears
            => _age + 4;

        public string OutputInfo
            => $"Имя:{Name}; возраст через 4 года: {AgeAfterFourYears} ";
    }
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
            }
            for (int i = 0; i < people.Length; i++)
            {
                string inputName;
                do
                {
                    Console.Write($"Введите имя {i + 1}го человека: ");
                    inputName = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(inputName));
                people[i].Name = inputName;
            }
            for (int i = 0; i < people.Length; i++)
            { 
                int inputAge;
                do
                {
                    Console.Write($"Введите возраст {i + 1}го человека: ");
                    
                } while (!int.TryParse(Console.ReadLine(), out inputAge));
                people[i].Age = inputAge;
            }
            foreach(var person in people)
            {
                Console.WriteLine(person.OutputInfo); 
            }
            Console.ReadKey();
        }
    }
}
