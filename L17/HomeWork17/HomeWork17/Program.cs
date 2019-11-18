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
            var info = new byte[100];
            for (int i = 0; i < info.Length; i++)
            {
                var random = new Random();
                info[i] = (byte)random.Next(0,255);
            }
                writer.WriteBytes("file1.txt", info, 0.05f);
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
