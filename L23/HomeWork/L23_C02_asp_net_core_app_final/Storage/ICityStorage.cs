using System;

namespace L23_C02_asp_net_core_app_final.Storage
{
	public interface ICityStorage
	{
		void Create(City city);
		City FindByName(string name);
		City[] GetAll();
		City GetById(Guid id);
	}
}