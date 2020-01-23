using System.Collections.Generic;

namespace L34_C01_working_with_ef_core
{
	class Customer
	{
		private Customer()
		{
		}

		public Customer(string name)
		{
			Name = name;
			Orders = new List<Order>();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public ICollection<Order> Orders { get; private set; }
	}
}
