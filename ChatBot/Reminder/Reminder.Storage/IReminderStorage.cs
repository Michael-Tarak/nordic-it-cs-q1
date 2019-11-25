using System;
using System.Collections.Generic;

namespace Reminder.Storage
{
    /// <summary>
    /// Определяет основные методы хранилища
    /// </summary>
    public interface IReminderStorage
    {
        /// <summary>
        /// Сохраняет новый элемент <see cref="ReminderItem">
        /// </summary>
        /// <param name="item">Элемент <see cref="ReminderItem"/></param>
        void Create(ReminderItem item);
        /// <summary>
        /// Обновляет данные элемента <see cref="ReminderItem">
        /// </summary>
        /// <param name="item">Элемент <see cref="ReminderItem"></param>

        void Update(ReminderItem item);
        /// <summary>
        /// Реализует поиск элемента  <see cref="ReminderItem"> по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <returns>Найденный элемент</returns>
        ReminderItem FindById(Guid id);
        /// <summary>
        /// Возвращает все элементы <see cref="ReminderItem"> по фильтру
        /// </summary>
        /// <param name="filter">Параметры фильтрации</param>
        /// <returns> Коллекция дат </returns>
        List<ReminderItem> FindBy(ReminderItemFilter filter);
    }
}
