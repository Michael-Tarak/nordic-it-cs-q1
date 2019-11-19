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
            //Arrange
            var storage = new ReminderStorage();
            //Act
            //Assert
            Assert.Catch<ArgumentNullException>(() =>
            storage.Create(null));
        }
        [Test]
        public void WhenCreate_IfExistElementWithKey_ShouldThrowException()
        {
            //Arrange
            var item = new ReminderItem(
                Guid.NewGuid(),
                "123",
                "Some text",
                DateTimeOffset.Now);
            var storage = new ReminderStorage(item);
            //Assert
            Assert.Catch<ArgumentException>(() =>
                storage.Create(item));

        }
        [Test]
        public void WhenUpdate_IfNotExistElementWithKey_ShouldThrowException()
        {
            var item = new ReminderItem(
                Guid.NewGuid(),
                "123",
                "Some text",
                DateTimeOffset.Now);
            var storage = new ReminderStorage();
            Assert.Catch<ArgumentException>(()=>
                storage.Update(item));
        }

    }
}