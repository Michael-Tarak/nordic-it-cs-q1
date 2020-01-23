namespace L34_C01_working_with_ef_core
{
	class OrderLine
	{
		private OrderLine()
		{
		}

		public OrderLine(Order order, int count, Product product)
		{
			Order = order;
			Count = count;
			Product = product;
		}

		public Order Order { get; private set; }
		public int Count { get; private set; }
		public Product Product { get; set; }

		public decimal Sum()
		{
			return Product.Price * Count;
		}
	}
}
