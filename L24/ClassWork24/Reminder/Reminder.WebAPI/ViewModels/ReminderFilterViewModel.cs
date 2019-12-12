using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminder.Storage;

namespace Reminder.WebAPI.ViewModels
{
    public class ReminderFilterViewModel
    {
        public ReminderItemStatus? Status { get; set; }
        public DateTimeOffset? Datetime { get; set; }

        public ReminderFilterViewModel()
        {

        }
    }
}
