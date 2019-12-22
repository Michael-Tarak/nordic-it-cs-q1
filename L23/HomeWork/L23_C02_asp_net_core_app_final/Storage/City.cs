using System;

namespace L23_C02_asp_net_core_app_final.Storage
{
	/// <summary>
	/// Модель города
	/// </summary>
	public class City
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Название города
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание города
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Население
		/// </summary>
		public int Population { get; set; }
	}
}