namespace HomeWork10
{
    class Person
    {
        private int _age;
        public string Name { get; set; }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if(value >= 0)
                {
                    _age = value;
                }
            }
        }
        public int AgeAfterFourYears
            => _age + 4;

        public string OutputInfo
            => $"Имя:{Name}; возраст через 4 года: {AgeAfterFourYears} ";
    }
}
