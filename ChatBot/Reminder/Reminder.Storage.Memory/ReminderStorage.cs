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

        public List<ReminderItem> FindByDateTime(DateTimeOffset dateTime)
        {
            var list = new List<ReminderItem>();

            foreach (var item in _map)
            {
                if (item.Value.MessageDate == dateTime)
                {
                    list.Add(item.Value);
                }
            }
            return list;
        }
        public ReminderItem FindById(Guid id)
        {
            if (!_map.ContainsKey(id))
            {
                throw new ArgumentException($"Не найден элемент с ключем {id}", nameof(id));
            }
            return _map[id];

        }
        public void Update(ReminderItem item)
        {
            if (!_map.ContainsKey(item.Id))
            {
                throw new ArgumentException($"Не найден элемент с ключем {item.Id}", nameof(item.Id));
            }
            else
            {
                _map[item.Id] = item;
            }
        }
    }
}
