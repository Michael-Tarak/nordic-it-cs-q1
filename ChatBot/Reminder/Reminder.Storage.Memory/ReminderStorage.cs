using System;
using System.Collections.Generic;

namespace Reminder.Storage.Memory
{
    public class ReminderStorage : IReminderStorage
    {
        private readonly Dictionary<Guid, ReminderItem> _map =
            new Dictionary<Guid, ReminderItem>();
        public void Create(ReminderItem item)
        {
            _map[item.Id] = item;
        }

        public List<ReminderItem> FindByDateTime(DateTimeOffset datetime)
        {
            throw new NotImplementedException();
        }

        public ReminderItem FindById(Guid id)
        {
            if(!_map.ContainsKey(id))
            {
                throw new ArgumentException($"Не найден элемент с ключом {id}", nameof(id));
            }
            return _map[id];
        }

        public void Update(ReminderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
