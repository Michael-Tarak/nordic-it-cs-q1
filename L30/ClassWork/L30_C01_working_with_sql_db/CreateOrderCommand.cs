using System;

namespace L30_C01_working_with_sql_db
{
	public class CreateOrderCommand
	{
		public class Line
		{
			public int ProductId { get; set; }
			public int Count { get; set; }

			public Line(int productId, int count)
			{
				ProductId = productId;
				Count = count;
			}
		}

		public int CustomerId { get; set; }
		public DateTimeOffset OrderDate { get; set; }
		public decimal Discount { get; set; }
		public Line[] Lines { get; set; }

		public CreateOrderCommand(
			int customerId,
			DateTimeOffset orderDate,
			decimal discount,
			params Line[] lines)
		{
			CustomerId = customerId;
			OrderDate = orderDate;
			Discount = discount;
			Lines = lines;
		}
	}
}
