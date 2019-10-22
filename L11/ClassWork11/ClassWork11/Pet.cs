namespace ClassWork11
{
    class Pet
    {
        public string Kind;
        public string Name;
        public char Sex;
        public byte Age;
        public string Description
        {
            get { return $"{Name} is a {Kind} ({Sex}) of {Age} years old"; }
        }
    }
}
