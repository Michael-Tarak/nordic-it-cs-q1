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
        public void WhenCreate_IfNullSpecified_ThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderService(new ReminderStorage()).Create(null));

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
        public void WhenOnReadyItemTimerTick_IfStorageContainsItemWithStatusNotReadyOrCreated_ShouldNotChangeStatus()
        {
            //Arrange
            var itemUndefied = new ReminderItem(
                        Guid.NewGuid(),
                        "ContactId",
                        "Mesage",
                        DateTimeOffset.Now,
                        ReminderItemStatus.Undefied);
            var itemSent = new ReminderItem(
                        Guid.NewGuid(),
                        "ContactId",
                        "Mesage",
                        DateTimeOffset.Now,
                        ReminderItemStatus.Sent);
            var itemFailed = new ReminderItem(
                        Guid.NewGuid(),
                        "ContactId",
                        "Mesage",
                        DateTimeOffset.Now,
                        ReminderItemStatus.Failed);

            var storage = new ReminderStorage(itemUndefied, itemSent, itemFailed);

            var service = new ReminderService(storage);

            //Act
            Thread.Sleep(2000);

            //Assert
            Assert.AreEqual(itemUndefied.Status, ReminderItemStatus.Undefied);
            Assert.AreEqual(itemFailed.Status, ReminderItemStatus.Failed);
            Assert.AreEqual(itemSent.Status, ReminderItemStatus.Sent);
        }
        
        [Test]
        public void WhenDeclare_IfNewItemCreated_ShouldSentItemOnDate()
        {
            //Arrange
            var item = new ReminderItem(
                        Guid.NewGuid(),
                        "ContactId",
                        "Mesage",
                        DateTimeOffset.Now);
            var service = new ReminderService(new ReminderStorage(item));

            //Act
            Thread.Sleep(3000);

            //Assert
            Assert.AreEqual(item.Status, ReminderItemStatus.Sent);
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
            service.ItemFailed += (sender, e) => result = true;
            service.ItemNotified += (sernder, e) => throw new Exception();

            //Act
            Thread.Sleep(2000);

            //Assert
            Assert.IsTrue(result);

        }
    }
}