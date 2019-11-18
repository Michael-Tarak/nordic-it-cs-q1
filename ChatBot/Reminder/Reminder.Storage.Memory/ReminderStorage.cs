using System;
using System.Linq;
using System.Collections.Generic;

namespace Reminder.Storage.Memory
{
    public class ReminderStorage : IReminderStorage
    {
        private readonly Dictionary<Guid, ReminderItem> _map;
        internal ReminderStorage(params ReminderItem[] items)
        {
            _map = items.ToDictionary(item => item.Id);
        }
        public ReminderStorage()
        {
            _map = new Dictionary<Guid, ReminderItem>();
        }
        public void Create(ReminderItem item)
        {
            if(item == default)
            {
                throw new ArgumentNullException("Предмету не присвоено значение",nameof(item));
            }
            if(_map.ContainsKey(item.Id))
            {
                throw new ArgumentException($"Предмет с таким идентификатором {item.Id} уже существует");
            }
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
