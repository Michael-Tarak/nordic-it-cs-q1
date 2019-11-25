using System;
using Reminder.Storage.Memory;
using NUnit.Framework;
using System.Threading;
using Reminder.Sender;

namespace Reminder.Domain.Tests
{
    public class ReminderServiceTests
    {
        private ReminderServiceParameters Parameters { get; } =
            new ReminderServiceParameters(
                createTimerInterval: TimeSpan.FromMilliseconds(50),
                createTimerDelay: TimeSpan.FromMilliseconds(50),
                readyTimerInterval: TimeSpan.FromMilliseconds(50),
                readyTimerDelay: TimeSpan.FromMilliseconds(50)
                );
        private ReminderStorage Storage =>
            new ReminderStorage();
        private IReminderSender SuccessSender =>
            new ReminderSenderFake();
        private IReminderSender FailureSender =>
    new ReminderSenderFake(shouldRaiseError: true);

        [Test]
        public void ItemSent_WhenReminderNotificationSent_ShouldRaiseEvent()
        {
            //Arrange
            var receiver = new ReminderReceiverFake();
            var service = new ReminderService(Storage, SuccessSender, null, Parameters);
            var eventRaised = false;
            //Act

            service.ItemSent += (sender, args) => eventRaised = true;
            receiver.Emit();
            WaitTimers();
            //Assert

            Assert.IsTrue(eventRaised);
        }
        [Test]
        public void ItemFailed_WhenReminderNotificationFailed_ShouldRaiseEvent()
        {
            //Arrange
            var receiver = new ReminderReceiverFake();
            var service = new ReminderService(Storage, FailureSender, null, Parameters);
            var eventRaised = false;
            //Act

            service.ItemFailed += (sender, args) => eventRaised = true;
            receiver.Emit();
            WaitTimers();
            //Assert

            Assert.IsTrue(eventRaised);
        }

        private void WaitTimers()
        {
            Thread.Sleep(Parameters.CreateTimerDelay +
                Parameters.ReadyTimerDelay +
                (Parameters.ReadyTimerInterval + Parameters.CreateTimerInterval) * 2);

        }
    }
}