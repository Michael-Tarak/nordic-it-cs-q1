using System;
using System.IO;

namespace HomeWork17
{
    class FileWriterWithProgress
    {
        public event EventHandler<WritingPerformedEventArgs> WritingPerformed;
        public event Action WritingCompleted;
        public void WriteBytes(string fileName, byte[] data, float persentageToFireEvent)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException($"Пустое имя файла {fileName}", nameof(fileName));
            }
            if (persentageToFireEvent <= 0 || persentageToFireEvent >= 1)
            {
                throw new ArgumentException($"Неверное значение " +
                    $"{persentageToFireEvent}(значение должно быть в пределах от 0 до 1)!",
                    nameof(persentageToFireEvent));
            }
            using var fileStream = new FileStream(fileName, FileMode.Create);
            float percentCounter = persentageToFireEvent;
            for (int i = 0; i < data.Length; i++)
            {
                fileStream.WriteByte(data[i]);
                if (percentCounter < ((float)(i + 1) / (float)data.Length))
                {
                    OnWritingPerformed(this, percentCounter);
                    percentCounter += persentageToFireEvent *
                        ((float)Math.Floor((((float)(i + 1) / (float)data.Length) - percentCounter) / persentageToFireEvent) + 1);
                }
            }
            OnWritingCompleted();
        }
        protected void OnWritingPerformed(
            object sender,
            double percentForNow)
        {
            var args = new WritingPerformedEventArgs
            {
                PercentForNow = percentForNow
            };
            WritingPerformed?.Invoke(sender, args);
        }
        protected void OnWritingCompleted()
        {
            WritingCompleted?.Invoke();
        }
    }
}
