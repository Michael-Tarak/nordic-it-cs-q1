using System;
using NUnit.Framework;
using Reminder.Domain.Models;

namespace ReminderDomainTests
{
    public class NotifyReminderModelTests
    {
        [Test]
        public void WhenDeclareNotifyReminderModel_IfNullSpecified_ShouldThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
               new NotifyReminderModel(null));
    }
}