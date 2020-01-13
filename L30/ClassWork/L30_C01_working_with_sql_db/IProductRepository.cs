using System.Collections.Generic;

namespace L30_C01_working_with_sql_db
{
	public interface IProductRepository
	{
		int GetCount();

		Product GetById(int id);

		List<Product> GetAll();

		int Insert(string name, decimal price);
	}
}
