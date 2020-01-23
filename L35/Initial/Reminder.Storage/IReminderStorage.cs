using System;

namespace Reminder.Storage
{
	// Интерфейс хранилища был расширен:
	// * Добавлена возможность пэйджинга
	// * Добавлены методы удаления / очистки хранилища
	// * Добавлены собственные типы исключений для предоставления исключительных ситуаций, вида
	//    - При поиске / обновлении / удалении, элемент не был найден (ReminderItemNotFoundException)
	//    - При создании, элемент уже существует (ReminderItemDuplicateException)

	/// <summary>
	///   The Reminder Items storage interface
	/// </summary>
	public interface IReminderStorage
	{
		/// <summary>
		///   Add new element to internal storage system <see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">The ReminderItem</param>
		void Add(ReminderItem item);

		/// <summary>
		///   Update Reminder Item state in internal storage system<see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">Элемент ReminderItem</param>
		void Update(ReminderItem item);

		/// <summary>
		///   Removes Reminder Item from storage by id
		/// </summary>
		void Delete(Guid id);

		/// <summary>
		///   Removes all Reminder Items from storage
		/// </summary>
		void Clear();

		/// <summary>
		///   Find one of <see cref="ReminderItem"/> with specified identity
		/// </summary>
		/// <param name="id">The Reminder Item Id</param>
		/// <returns>Founded reminder item<see cref="ReminderItem"/></returns>
		ReminderItem FindById(Guid id);

		/// <summary>
		///   Find all reminder items <see cref="ReminderItem" /> matching specified filter
		/// </summary>
		/// <param name="filter">The filter object <see cref="ReminderItemFilter" /></param>
		/// <returns>The paged result</returns>
		PagedResult FindBy(ReminderItemFilter filter);
	}
}
