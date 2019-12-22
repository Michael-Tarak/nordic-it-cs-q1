using System;

namespace L23_C02_asp_net_core_app_final.Storage
{
	/// <summary>
	/// ������ ������
	/// </summary>
	public class City
	{
		/// <summary>
		/// �������������
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// �������� ������
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// �������� ������
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// ���������
		/// </summary>
		public int Population { get; set; }
	}
}