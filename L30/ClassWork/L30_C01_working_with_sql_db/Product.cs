namespace L30_C01_working_with_sql_db
{
	public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public Product(
			int id,
			string name,
			decimal price)
		{
			Id = id;
			Name = name;
			Price = price;
		}
	}
}
