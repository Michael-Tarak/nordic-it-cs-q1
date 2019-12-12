using NUnit.Framework;
using Reminder.Domain;
using Reminder.Domain.Models;
using Reminder.Storage.Memory;
using System;
using Reminder.Storage;

namespace ReminderDomainTests
{
    public class ReminderServiceTests
    {

        [Test]
        public void WhenDeclare_IfNullSpecified_ThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(
                () => new ReminderService(null));

        [Test]
        public void WhenCreate_IfNullSpecified_ThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderService(new ReminderStorage()).Create(null));

        [Test]
        public void When
    }
}