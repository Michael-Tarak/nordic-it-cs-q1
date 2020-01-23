using System.Collections.Generic;

namespace L34_C01_working_with_ef_core
{
	class Customer
	{
		private Customer()
		{
            Orders = new HashSet<Order>();
		}

		public Customer(string name, string lastname)
            :this()
		{
			Name = name;
            Lastname = lastname;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
        public string Lastname { get; private set; }
		public ICollection<Order> Orders { get; private set; }
	}
}
