using System;
using System.Threading;

namespace ClassWork17
{
    public class RandomDateGeneratedHandler
    {
        public int BytesDone { get; set; }
        public int TotalBytes { get; set; }
    }
    class RandomDateGenerator
    {
        public event EventHandler<RandomDateGeneratedHandler> RandomDataGenerating;
        public event EventHandler RandomDateGenerated;
        public byte [] GetRandomData(int datasize, int bytesDoneToRaiseEvent)
        {
            var fullData = new byte[datasize];
            for (int i = 0; i < fullData.Length; i++)
            {
                Random random = new Random();
                fullData[i] = (byte)random.Next();
                if(i % bytesDoneToRaiseEvent == 0 && i != 0)
                {
                    RandomDataGenerating?.Invoke(i, fullData.Length);
                }
            }
            RandomDateGenerated(this, null);
            return fullData;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new RandomDateGenerator();
            generator.RandomDataGenerating += Generator_RandomDataGenerating;
            generator.RandomDateGenerated += Generator_RandomDateGenerated;
            var data = generator.GetRandomData(1000, 150);

        }

        private static void Generator_RandomDateGenerated(object sender, EventArgs e)
        {
            Console.WriteLine("Generation done");
        }

        private static void Generator_RandomDataGenerating(int bytesDone, int totalBytes)
        {
            Console.WriteLine($"Generate {bytesDone} out of {totalBytes}");
        }
    }
}
