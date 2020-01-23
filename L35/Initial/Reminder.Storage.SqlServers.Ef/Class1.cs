using Microsoft.EntityFrameworkCore;
using System;

namespace Reminder.Storage.SqlServers.Ef
{
    public class ReminderItemEntity
    {
        public Guid Id { get; set; }
    }
    public class ContactEntity
    {
        public Guid Id { get; set; }
        public string  Login { get; set; }
    }
    public class ReminderStorageContext : DbContext
    {

    }
}
