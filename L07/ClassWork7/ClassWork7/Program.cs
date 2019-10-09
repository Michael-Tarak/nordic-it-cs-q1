using System;
using System.Text;

namespace ClassWork7
{
    class Program
    {
        static string text = "  lorem     ipsum     dolor     sit     amet  ";

        static void Main(string[] args)
        {
            WithoutStringBuilder();
            WithStringBuilder();
        }
        static void WithoutStringBuilder()
        {
            var input1 = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var methodText = text.TrimEnd();
            var input3 = methodText.Split();
            input1[1] = input1[1].ToUpper();
            var output1 = String.Join(" ", input1);
            string[] input2 = new string[input3.Length - 1];
            for (int i = 0; i < input2.Length; i++)
            {
                input2[i] = input3[i];
            }
            var output2 = String.Join(" ", input2);
            Console.WriteLine(output1);
            Console.WriteLine(output2);
        }
        static void WithStringBuilder()
        {
            var methodText = text.Trim();
            var textMassive = methodText.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            textMassive[1] = textMassive[1].ToUpper();
            var input1 = new StringBuilder();
            for (int i = 0; i < textMassive.Length - 1; i++)
            {
                input1.Append(textMassive[i] + " ");

            }
            Console.WriteLine(input1);
        }
    }
}
