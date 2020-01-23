using System;

namespace Reminder.Storage.SqlServers.Ef
{
    public class ReminderStorage : IReminderStorage
    {
        public void Add(ReminderItem item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PagedResult FindBy(ReminderItemFilter filter)
        {
            throw new NotImplementedException();
        }

        public ReminderItem FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ReminderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
