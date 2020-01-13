using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace L30_C01_working_with_sql_db
{
	public class ProductRepository : IProductRepository
	{
		private readonly string _connection;

		public ProductRepository()
		{
		}

		public ProductRepository(string connection)
		{
			_connection = connection;
		}

		public List<Product> GetAll()
		{
			using var connection = CreateConnection();
			using var command = connection.CreateCommand();

			command.CommandType = CommandType.Text;
			command.CommandText = "SELECT [Id],[Name],[Price] FROM [Product] ORDER BY [Name];";

			using var reader = command.ExecuteReader();

			var result = new List<Product>();

			if (!reader.HasRows)
			{
				return result;
			}

			// Second option, read by indexes
			var idIndex = reader.GetOrdinal("Id");
			var nameIndex = reader.GetOrdinal("Name");
			var priceIndex = reader.GetOrdinal("Price");

			while (reader.Read())
			{
				// First option, read by names 
				// var id = reader.GetInt32("Id");
				// var name = reader.GetString("Name");
				// var price = (decimal)reader.GetDecimal("Price");

				var id = reader.GetInt32(idIndex);
				var name = reader.GetString(nameIndex);
				var price = reader.GetDecimal(priceIndex);
				var product = new Product(id, name, price);

				result.Add(product);
			}

			return result;
		}

		public Product GetById(int id)
		{
			throw new NotImplementedException();
		}

		public int GetCount()
		{
			using var connection = CreateConnection();
			using var command = connection.CreateCommand();

			command.CommandType = CommandType.Text;
			command.CommandText = "SELECT COUNT(*) FROM Product";
			var result = command.ExecuteScalar();
			return (int)result;
		}

		public int Insert(string name, decimal price)
		{
			using var connection = CreateConnection();
			using var command = connection.CreateCommand();

			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "sp_AddProduct";
			command.Parameters.AddWithValue("@p_name", name);
			command.Parameters.AddWithValue("@p_price", price);

			var idParameter = new SqlParameter("@p_id", SqlDbType.Int)
			{
				Direction = ParameterDirection.Output
			};
			command.Parameters.Add(idParameter);
			command.ExecuteNonQuery();

			return (int)idParameter.Value;
		}

		private SqlConnection CreateConnection()
		{
			var connection = new SqlConnection(_connection);
			connection.Open();
			return connection;
		}
	}
}
