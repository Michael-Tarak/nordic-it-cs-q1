using System;

namespace Reminder.Storage
{
    /// <summary>
    /// Определяет основные методы хранилища
    /// </summary>
    public interface IReminderStorage
    {
        bool Create(
            string message,
            string contactId,
            DateTimeOffset messageDate);
        void Update(
            string message,
            string contactId,
            DateTimeOffset messageDate);
        ReminderItem FindById(Guid id);
    }
}
