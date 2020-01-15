using System;
using System.Collections.Generic;

namespace Reminder.Storage.SqlServer
{
    public class ReminderStorage : IReminderStorage
    {
        public void Add(ReminderItem item)
        {
            throw new NotImplementedException();
        }

        public List<ReminderItem> FindBy(ReminderItemFilter filter)
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
