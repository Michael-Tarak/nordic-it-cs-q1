using Reminder.Receiver;
using Reminder.Sender;
using Reminder.Storage;
using System;
using System.Threading;

namespace Reminder.Domain
{
    public class ReminderService : IDisposable
    {
        public event EventHandler ItemSent;
        public event EventHandler ItemFailed;

        private readonly IReminderStorage _storage;
        private readonly IReminderSender _sender;
        private readonly IReminderReceiver _receiver;
        private readonly Timer _createdItemTimer;
        private readonly Timer _readyItemTimer;


        public ReminderService(
            IReminderStorage storage,
            IReminderSender sender,
            IReminderReceiver receiver,
            ReminderServiceParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _receiver.MessageReceived += OnMessageReceived;
            _createdItemTimer = new Timer(OnCreatedItemTimerTick, null,
                parameters.CreateTimerDelay, parameters.CreateTimerInterval);
            _readyItemTimer = new Timer(OnReadyItemTimerTick, null,
                parameters.ReadyTimerDelay, parameters.ReadyTimerInterval);
        }
        public void Dispose()
        {
            _createdItemTimer.Dispose();
            _readyItemTimer.Dispose();
            _receiver.MessageReceived -= OnMessageReceived;
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
                    _sender.Send(
                        new Notification(item.ContactId, item.Message, item.MessageDate)
                    );
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
        private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            var item = new ReminderItem(
                Guid.NewGuid(),
                args.ContactId,
                args.Message.Text,
                args.Message.Datetime);

            _storage.Create(item);
        }

    }
}
