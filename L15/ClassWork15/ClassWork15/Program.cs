using System;

namespace ClassWork15
{
    class Account<T>
    {
        public T Id { get; private set; }
        public string Name { get; private set; }
        public Account ( T id, string name)
        {
            Id = id;
            Name = name;
        }
        public void WriteProperties()
        {
            Console.WriteLine($"{nameof(Id)}: {Id}\n" +
                $"{nameof(Name)}: {Name}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var accountInteger = new Account<int>(1, "John");
            var accountString = new Account<string>("2", "John");
            var accountGuid = new Account<Guid>(Guid.NewGuid(), "John");
            accountInteger.WriteProperties();
            accountString.WriteProperties();
            accountGuid.WriteProperties();
        }
    }
}
