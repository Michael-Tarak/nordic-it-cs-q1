using NUnit.Framework;
using Reminder.Receiver.Telegram;
using System;

namespace Reminder.Receiver.Tests
{
    public class ReminderReceiverTests
    {
        [Test]
        public void WhenDeclare_IfArgumentTokenNullSpecified_ShouldThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderReceiver(null));

        [Test]
        public void WhenOnMessage_IfMessageIsCorrect_ShouldRaiseEvent()
        {

        }
    }
}