using System.Collections.Generic;

namespace L34_C01_working_with_ef_core
{
	class Product
	{
		private Product()
		{
		}

		public Product(string name, decimal price)
		{
			Name = name;
			Price = price;
			OrderLines = new List<OrderLine>();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public ICollection<OrderLine> OrderLines { get; private set; }
	}
}
