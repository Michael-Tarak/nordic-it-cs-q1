using System;
using NUnit.Framework;

namespace Reminder.Storage.Memory.Test
{
    public class ReminderStorageTests
    {
        [Test]
        public void WhenCreate_IfEmptyStorage_ShouldFindItemById()
        {
            //Arrange
            var item = new ReminderItem(Guid.NewGuid(), "112", "Some text", DateTimeOffset.Now);
            var storage = new ReminderStorage();
            //Act
            storage.Create(item);
            //Assert
            var result = storage.FindById(item.Id);
            Assert.AreEqual(item.Id, result.Id);
        }
        [Test]
        public void WhenCreate_IfNullSpecified_ShouldThrowException()
        {
            var storage = new ReminderStorage();
            Assert.Catch<ArgumentNullException>(() =>
            storage.Create(null));
        }
        public void WhenCreate_IfExistsElementWithKey_ShouldThrowException()
        {
            var item = new ReminderItem(Guid.NewGuid(), "112", "Some text", DateTimeOffset.Now);
            var storage = new ReminderStorage(item);
            Assert.Catch<ArgumentException>(() =>
                storage.Create(null));

        }

    }
}