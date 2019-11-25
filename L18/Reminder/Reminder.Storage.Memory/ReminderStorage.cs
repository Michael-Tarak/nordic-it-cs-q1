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
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			if (_map.ContainsKey(item.Id))
			{
				throw new ArgumentException($"Уже существует элемент с идентификатором {item.Id}");
			}
			_map[item.Id] = item;
		}

		public List<ReminderItem> FindByDateTime(DateTimeOffset dateTime)
		{
            if(dateTime == default)
            {
                throw new ArgumentNullException("Не указана дата", nameof(dateTime));
            }
            var list = new List<ReminderItem>();
            foreach (var item in _map.Where(item => item.Value.MessageDate == dateTime))
            {
                list.Add(item.Value);
            }
            if(list.Count < 1)
            {
                throw new ArgumentException("По данной дате записей нет", nameof(dateTime));
            }
            return list;
        }

		public ReminderItem FindById(Guid id)
		{
			if (!_map.ContainsKey(id))
			{
				throw new ArgumentException($"Не найден элемент с ключом {id}", nameof(id));
			}

			return _map[id];
		}

		public void Update(ReminderItem item)
		{
            if(item == null)
            {
                throw new ArgumentNullException("Аргумент пуст", nameof(item));
            }
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
