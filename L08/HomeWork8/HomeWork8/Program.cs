using System;
using System.Collections.Generic;

namespace HomeWork8
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            while(true)
            {
                Console.WriteLine("Введите строку, используя символы \"[\" , \"]\" , \"(\", \")\"");
                var mainInput = Console.ReadLine();
                if (mainInput.ToLower() == "exit")
                    break;
                if (string.IsNullOrWhiteSpace(mainInput))
                {
                    Console.WriteLine("Пустой ввод!");
                    continue;
                }

                Console.WriteLine(Qualifier(mainInput));
            }
        }

        private static bool Qualifier(string input)
        {
            var Brakets = new Stack<string> { };
            //var circleBrakets = new Stack<bool> { };
            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '(':
                        Brakets.Push("circle");
                            break;
                    case ')':
                        if(Brakets.Count == 0)
                            return false;
                        if (Brakets.Peek() != "circle")
                            return false;
                        Brakets.Pop();
                        break;
                    case '[':
                        Brakets.Push("square");
                        break;
                    case ']':
                        if (Brakets.Count == 0)
                            return false;
                        if (Brakets.Peek() != "square")
                            return false;

                        Brakets.Pop();
                        break;
                    default:
                        Console.WriteLine("Присутсвует лишний символ!");
                        return false;
                }
            }
            return Brakets.Count == 0;
        }
    }
}
