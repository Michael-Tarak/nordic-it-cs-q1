namespace ClassWork10
{
    class Pet
    {
        public string Kind;
        public string Name;
        public char Sex;
        public int Age;
        public string Description
        {
            get
            {
                return $"The pet kind {Kind}, name is {Name} age {Age} sex: {Sex}";
            }
        }
    }
}
