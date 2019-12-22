using NUnit.Framework;
using Reminder.Domain;
using Reminder.Domain.Models;
using Reminder.Storage.Memory;
using System;
using Reminder.Storage;
using System.Threading;

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
        public void WhenOnReadyItemTimerTick_IfStorageContainsItemWithStatusReady_ShouldBeChangedToStatusSent()
        {
            //Arrange
            var item = new ReminderItem(
                        Guid.NewGuid(),
                        "ContactId",
                        "Mesage",
                        DateTimeOffset.Now,
                        ReminderItemStatus.Ready);

            var storage = new ReminderStorage(item);

            var service = new ReminderService(storage);

            //Act
            Thread.Sleep(2000);

            //Assert
            Assert.AreEqual(item.Status, ReminderItemStatus.Sent);
        }

        [Test]
        [TestCase(ReminderItemStatus.Failed)]
        [TestCase(ReminderItemStatus.Sent)]
        public void WhenOnReadyItemTimerTick_IfStorageContainsItemWithStatusNotReadyOrCreated_ShouldNotChangeStatus(ReminderItemStatus status)
        {
            //Arrange
            var itemSent = new ReminderItem(
                        Guid.NewGuid(),
                        "ContactId",
                        "Mesage",
                        DateTimeOffset.Now,
                        status);

            var storage = new ReminderStorage(itemSent);

            var service = new ReminderService(storage);

            //Act
            Thread.Sleep(2000);

            //Assert
            Assert.AreEqual(itemSent.Status, status);
        }
        
        [Test]
        public void WhenCreate_IfNewItemCreated_ShouldSendItemOnDate()
        {
            //Arrange
            var result = false;
            var service = new ReminderService(new ReminderStorage());

            //Act
            service.ItemSent += (sender, e) => result = true;
            service.Create(new CreateReminderModel("contact", "message", DateTimeOffset.Now));
            Thread.Sleep(3000);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void WhenOnReadyItemTimerTick_IfExceptionCatched_ShouldRaiseEventItemFailed()
        {
            //Arrange
            var item = new ReminderItem(
                        Guid.NewGuid(),
                        "ContactId",
                        "Mesage",
                        DateTimeOffset.Now,
                        ReminderItemStatus.Ready);
            var service = new ReminderService(new ReminderStorage(item));
            var result = false;

            //Act
            service.ItemFailed += (sender, e) => result = true;
            service.ItemNotified += (sernder, e) => throw new Exception();
            Thread.Sleep(2000);

            //Assert
            Assert.IsTrue(result);
        }
    }
}