﻿using System;
using System.Threading;
using Reminder.Storage;
using Reminder.Domain.Models;

namespace Reminder.Domain
{
	public class ReminderService : IDisposable
	{
		public event EventHandler<NotifyReminderModel> ItemNotified;
		public event EventHandler ItemSent;
		public event EventHandler ItemFailed;

		private readonly Timer _createdItemTimer;
		private readonly Timer _readyItemTimer;
		private readonly IReminderStorage _storage;

		public ReminderService(IReminderStorage storage)
		{
            if(storage == null)
            {
                throw new ArgumentNullException(nameof(storage));
            }
			_storage = storage;
			_createdItemTimer = new Timer(OnCreatedItemTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
			_readyItemTimer = new Timer(OnReadyItemTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
		}

		public void Dispose()
		{
			_createdItemTimer.Dispose();
			_readyItemTimer.Dispose();
		}

		public void Create(CreateReminderModel model)
		{
            if(model == null)
            {
                throw new ArgumentNullException("Пустой аргумент", nameof(model));
            }
			var item = new ReminderItem(
                Guid.NewGuid(),
                model.ContactId,
				model.Message,
				model.Datetime);

			_storage.Create(item);
		}

		private void OnCreatedItemTimerTick(object _)
		{
			var filter = ReminderItemFilter
				.ByStatus(ReminderItemStatus.Created)
				.At(DateTimeOffset.UtcNow);
			var items = _storage.FindBy(filter);

			foreach (var item in items)
			{
				_storage.Update(item.ReadyToSend());
			}
		}

		private void OnReadyItemTimerTick(object _)
		{
			var filter = ReminderItemFilter.ByStatus(ReminderItemStatus.Ready);
			var items = _storage.FindBy(filter);

			foreach (var item in items)
			{
				try
				{
					ItemNotified?.Invoke(this, new NotifyReminderModel(item));
					OnItemSent(item);
				}
				catch (Exception ex)
				{
					OnItemFailed(item);
				}
			}
        }

        private void OnItemSent(ReminderItem item)
		{
			_storage.Update(item.Sent());
			ItemSent?.Invoke(this, EventArgs.Empty);
		}

		private void OnItemFailed(ReminderItem item)
		{
			_storage.Update(item.Failed());
			ItemFailed?.Invoke(this, EventArgs.Empty);
		}
	}
}
