using System.Data;
using Microsoft.Data.SqlClient;

namespace L30_C01_working_with_sql_db
{
	public class OrderRepository : IOrderRepository
	{
		private readonly string _connection;

		public OrderRepository(string connection)
		{
			_connection = connection;
		}

		public int Insert(CreateOrderCommand dto)
		{
			using var connection = CreateConnection();
			using var transaction = connection.BeginTransaction();

			try
			{
				using var orderCommand = connection.CreateCommand();
				orderCommand.Transaction = transaction;
				orderCommand.CommandType = CommandType.StoredProcedure;
				orderCommand.CommandText = "sp_AddOrder";
				orderCommand.Parameters.AddWithValue("@p_customerId", dto.CustomerId);
				orderCommand.Parameters.AddWithValue("@p_orderDate", dto.OrderDate);
				if (dto.Discount != 0)
				{
					orderCommand.Parameters.AddWithValue("@p_discount", dto.Discount);
				}
				var orderId = new SqlParameter("@p_id", SqlDbType.Int)
				{
					Direction = ParameterDirection.Output
				};
				orderCommand.Parameters.Add(orderId);
				orderCommand.ExecuteNonQuery();

				using var orderlineCommand = connection.CreateCommand();
				orderlineCommand.Transaction = transaction;
				orderlineCommand.CommandType = CommandType.StoredProcedure;
				orderlineCommand.CommandText = "sp_AddOrderLine";

				foreach (var orderLine in dto.Lines)
				{
					orderlineCommand.Parameters.Clear();
					orderlineCommand.Parameters.AddWithValue("@p_orderId", (int)orderId.Value);
					orderlineCommand.Parameters.AddWithValue("@p_productId", orderLine.ProductId);
					orderlineCommand.Parameters.AddWithValue("@p_count", orderLine.Count);
					orderlineCommand.ExecuteNonQuery();
				}

				transaction.Commit();

				return (int)orderId.Value;
			}
			catch (SqlException)
			{
				transaction.Rollback();
				throw;
			}
		}

		private SqlConnection CreateConnection()
		{
			var connection = new SqlConnection(_connection);
			connection.Open();
			return connection;
		}
	}
}
