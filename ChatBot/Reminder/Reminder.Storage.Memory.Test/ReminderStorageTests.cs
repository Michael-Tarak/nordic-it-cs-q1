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
        [Test]
        public void WhenFindByDateTime_IfDateTimeIsDefault_ThrowException()
        {
            var reminderStorage = new ReminderStorage(); 
            Assert.Catch<ArgumentException>(()=>
                reminderStorage.FindBy(default));
        }
        [Test]
        public void WhenFindByDateTime_IsSpecifiedDateTime_ShouldFilterByIt()
        {
            var storage = new ReminderStorage(
                CreateReminderItem(messageDate: DateTimeOffset.Parse("12.11.2019 14:28:00.00"))
                );
            var result = storage.FindBy(
                DateTimeOffset.Parse("12.11.2019 14:28:00.00")
                );
            Assert.IsNotEmpty(result);
        }
        private ReminderItem CreateReminderItem(
            Guid? id = default,
            string contactId = default,
            string message = default,
            DateTimeOffset? messageDate = default
            )
        {
            if(!id.HasValue)
            {
                id = Guid.NewGuid();
            }
            if(contactId == null)
            {
                contactId = "123";
            }
            if(message == null)
            {
                message = "Some text";
            }
            if(!messageDate.HasValue)
            {
                messageDate = DateTimeOffset.UtcNow;
            }
            return new ReminderItem(id.Value, contactId, message, messageDate.Value);
        }
    }
}