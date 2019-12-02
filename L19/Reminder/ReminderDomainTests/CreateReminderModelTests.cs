using System;
using Reminder.Domain.Models;
using NUnit.Framework;

namespace ReminderDomainTests
{
    public class CreateReminderModelTests
    {
        [Test]
        public void WhenDeclareCreateReminderItem_IfArgumentContactIdNullSpecified_ShouldThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch(() =>
                new CreateReminderModel(null, "message", DateTimeOffset.Now));

        [Test]
        public void WhenDeclareCreateReminderItem_IfArgumentMessageNullSpecified_ShouldThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch(() =>
                new CreateReminderModel("somebody", "", DateTimeOffset.Now));
        [Test]
        public void WhenDeclareCreateReminderItem_IfArgumentDateTimeDefaultSpecified_ShouldThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch(() =>
                new CreateReminderModel("somebody", "message", default));
    }
}