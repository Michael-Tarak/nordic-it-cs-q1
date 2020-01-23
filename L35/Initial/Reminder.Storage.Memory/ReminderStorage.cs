using System;
using System.Linq;
using System.Collections.Generic;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.Memory
{
	public class ReminderStorage : IReminderStorage
	{
		private readonly Dictionary<Guid, ReminderItem> _dictionary;

		internal ReminderStorage(params ReminderItem[] items)
		{
			_dictionary = items.ToDictionary(item => item.Id);
		}

		public ReminderStorage()
		{
			_dictionary = new Dictionary<Guid, ReminderItem>();
		}

		public void Add(ReminderItem item)
		{
			if (item == default)
			{
				throw new ArgumentNullException(nameof(item));
			}

			if (_dictionary.ContainsKey(item.Id))
			{
				throw new ReminderItemDuplicateException(item.Id);
			}

			_dictionary[item.Id] = item;
		}

		public void Update(ReminderItem item)
		{
			if (item == default)
			{
				throw new ArgumentNullException(nameof(item));
			}

			if (!_dictionary.ContainsKey(item.Id))
			{
				throw new ReminderItemNotFoundException(item.Id);
			}

			_dictionary[item.Id] = item;
		}

		public void Delete(Guid id)
		{
			if (id == default)
			{
				throw new ArgumentException(nameof(id));
			}

			if (!_dictionary.ContainsKey(id))
			{
				throw new ReminderItemNotFoundException(id);
			}

			_dictionary.Remove(id);
		}

		public void Clear()
		{
			_dictionary.Clear();
		}

		public ReminderItem FindById(Guid id)
		{
			if (id == default)
			{
				throw new ArgumentException(nameof(id));
			}

			if (!_dictionary.TryGetValue(id, out var item))
			{
				throw new ReminderItemNotFoundException(id);
			}

			return item;
		}

		public PagedResult FindBy(ReminderItemFilter filter)
		{
			if (filter == null)
			{
				throw new ArgumentNullException(nameof(filter));
			}

			var result = _dictionary.Values.AsEnumerable();

			if (filter.ByStatus)
			{
				result = result.Where(_ => _.Status == filter.Status);
			}

			if (filter.ByDatetime)
			{
				result = result.Where(_ => _.DatetimeUtc < filter.DatetimeUtc);
			}

			var items = result
				.OrderBy(_ => _.DatetimeUtc)
				.Skip(filter.Page.Offset)
				.Take(filter.Page.Limit);

			return new PagedResult(
				result.Count(),
				filter.Page,
				items
			);
		}
	}
}
