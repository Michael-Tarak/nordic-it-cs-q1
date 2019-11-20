using System;
namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new FileWriterWithProgress();
            writer.WritingPerformed += OnWritingPerformed;
            writer.WritingCompleted += OnWritingCompleted;
            var info = new byte[10000];
            new Random().NextBytes(info);
            writer.WriteBytes("file1.txt", info, 0.07f);
        }
        private static void OnWritingPerformed(object sender, WritingPerformedEventArgs e)
        {
            Console.WriteLine($"Запись выполнена на {e.PercentForNow.ToString("00.00")}%");
        }
        private static void OnWritingCompleted()
        {
            Console.WriteLine("Запись закончена!");
        }
    }
}
