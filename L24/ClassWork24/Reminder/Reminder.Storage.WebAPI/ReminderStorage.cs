using System;
using System.Collections.Generic;

namespace Reminder.Storage.WebAPI
{
    public class ReminderStorage : IReminderStorage
    {
        //HTTP POST /api/reminders
        public void Create(ReminderItem item)
        {
            throw new NotImplementedException();
        }

        //HTTP GET /api/reminders?
        public List<ReminderItem> FindBy(ReminderItemFilter filter)
        {
            throw new NotImplementedException();
        }

        //HTTP GET /api/reminders/id
        public ReminderItem FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        //HTTP PUT /api/reminders/id
        public void Update(ReminderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
