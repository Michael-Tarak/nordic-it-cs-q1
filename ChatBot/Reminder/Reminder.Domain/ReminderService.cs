using Reminder.Storage;
using System;
using System.Threading;

namespace Reminder.Domain
{
    public class CreateReminderModel
    {
        public string ContactId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset MessageDate { get; set; }
    }
    public class ReminderService
    {
        private readonly Timer _createdItemTimer;
        private readonly Timer _readyItemTimer;
        private readonly IReminderStorage _storage;
        public ReminderService(IReminderStorage storage)
        {
            _storage = storage;
            _createdItemTimer = new Timer(OnCreatedItemTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            _readyItemTimer = new Timer(OnReadyItemTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

        }
        private void OnCreatedItemTimerTick(object state)
        {
            var filter = new ReminderItemFilter()
                .At(DateTimeOffset.Now)
                .Created();
            var items = _storage.FindBy(filter);
            foreach(var item in items)
            {
                _storage.Update(item.ReadyToSend());
            }
        }
    }

    private void OnReadyItemTimerTick(object state)
    {
        throw new NotImplementedException();
    }


    public void Create(CreateReminderModel model)
    {
        var item = new ReminderItem(
            Guid.NewGuid(),
            model.ContactId,
            model.Message,
            model.MessageDate
            );
        _storage.Create(item);
    }
    private void OnTimerTick(object state)
    {
        var filter = new ReminderItemFilter()
            .At(DateTimeOffset.Now)
            .Created();
        foreach (var item in items)
        {

            _storage.Update(item.ReadyToSend());
        }
    }
    public void Start()
    {

    }
}
}
