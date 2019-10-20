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
                if (string.IsNullOrWhiteSpace(mainInput))
                {
                    Console.WriteLine("Пустой ввод!");
                    continue;
                }
                if (mainInput.ToLower() == "exit")
                {
                    break;
                }
                Console.WriteLine(Qualifier(mainInput));
            }
        }

        private static bool Qualifier(string input)
        {
            var brakets = new Stack<char> { };
            foreach (var symbol in input)
            {
                
                if (symbol == '(' || symbol == '[')
                {
                    brakets.Push(symbol);
                }
                else if (symbol == ')' || symbol == ']')
                {
                    if(brakets.Count == 0)
                    {
                        return false;
                    }
                    bool circleBracketCheck = symbol == ')' && brakets.Peek() != '(';
                    bool squareBracketCheck = symbol == ']' && brakets.Peek() != '[';
                    if (circleBracketCheck || squareBracketCheck)
                    {
                        return false;
                    }
                    brakets.Pop();
                }
                else 
                {
                    Console.WriteLine("Присутсвует лишний символ!");
                    return false;
                }
            }
            return brakets.Count == 0;
        }
    }
}
