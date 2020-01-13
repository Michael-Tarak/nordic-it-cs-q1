namespace L30_C01_working_with_sql_db
{
	public interface IOrderRepository
	{
		int Insert(CreateOrderCommand dto);
	}
}
