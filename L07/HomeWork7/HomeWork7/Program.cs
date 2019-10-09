using System;
using System.Text;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string input;
            do
            {
                Console.Write("Выберите номер домашнего задания:");
                input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        FirstHomeWork();
                        break;
                    case "2":
                        SecondHomeWork();
                        break;
                    default:
                        break;
                }
            }
            while (input != "exit");
            FirstHomeWork();
        }
        static void FirstHomeWork()
        {
            string input;
            do
            {
                Console.WriteLine("Введите строку из нескольких слов: Для выхода из программы введите \"exit\"");
                input = Console.ReadLine();
                input = input.Trim();
                if (input == "exit")
                    break;
                var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (words.Length < 2)
                {
                    Console.WriteLine("Слишком мало слов :( Попробуйте еще раз");
                    continue;
                }
                int counter = 0;
                foreach (var word in words)
                {
                    if (word[0] == 'а')
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"Количество слов, начинающихся с буквы \'а\': {counter}");
            }
            while (true);

        }
        static void SecondHomeWork()
        {
            string input;
            do
            {
                Console.WriteLine("Введите непустую строку:");
                input = Console.ReadLine();
                if (input == "exit")
                    break;
                if( input == "")
                {
                    Console.WriteLine("Вы ввели пустую строку");
                    continue;
                }
                var sbInput = new StringBuilder(input);
                for (int i = 0; i < sbInput.Length / 2; i++)
                {
                    var tempChar = input[i];
                    sbInput[i] = input[input.Length - i- 1];
                    sbInput[input.Length - 1 - i] = tempChar;
                }
                Console.WriteLine(sbInput);
            } while (true);

        }
    }
}
