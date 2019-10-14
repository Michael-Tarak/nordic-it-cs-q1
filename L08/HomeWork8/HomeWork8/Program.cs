using System;
using System.Collections.Generic;

namespace HomeWork8
{
    class Program
    {
        static Stack<bool> squareBrakets = new Stack<bool> { };
        static Stack<bool> circleBrakets = new Stack<bool> { };

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
                Console.WriteLine(Qualifier(mainInput));
                squareBrakets.Clear();
                circleBrakets.Clear();
            }
        }

        private static bool Qualifier(string input)
        {
            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '(':
                        circleBrakets.Push(true);
                            break;
                    case ')':
                        if(circleBrakets.Count == 0)
                            return false;
                        circleBrakets.Pop();
                        break;
                    case '[':
                        squareBrakets.Push(true);
                        break;
                    case ']':
                        if (squareBrakets.Count == 0)
                            return false;
                        squareBrakets.Pop();
                        break;
                    default:
                        Console.WriteLine("Присутсвует лишний символ!");
                        return false;
                }
            }
            if (squareBrakets.Count == 0 && circleBrakets.Count == 0)
                return true;
            else
                return false;
        }
    }
}
