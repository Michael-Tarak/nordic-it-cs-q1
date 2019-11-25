using NUnit.Framework;
using System;

namespace Reminder.Storage.Memory.Tests
{
    public class ReminderStorageTests
    {
        // WhenUnit_IfCondition_ShouldExpectedResult

        [Test]
        public void WhenCreate_IfEmptyStorage_ShouldFindItemById()
        {
            // Arrange
            var item = CreateReminderItem();
            var storage = new ReminderStorage();

            // Act
            storage.Create(item);

            // Assert
            var result = storage.FindById(item.Id);
            Assert.AreEqual(item.Id, result.Id);
        }

        [Test]
        public void WhenCreate_IfNullSpecified_ShouldThrowException()
        {
            // Arrange
            var storage = new ReminderStorage();

            // Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                storage.Create(null)
            );
        }

        [Test]
        public void WhenCreate_IfExistsElementWithKey_ShouldThrowException()
        {
            // Arrange
            var item = CreateReminderItem();
            var storage = new ReminderStorage(
                item
            );

            // Act-Assert
            Assert.Catch<ArgumentException>(() =>
                storage.Create(item)
            );
        }

        [Test]
        public void WhenFindByDateTime_IfDefaultSpecified_ShouldThrowException()
        {
            var storage = new ReminderStorage();
            Assert.Catch<ArgumentNullException>(() => storage.FindByDateTime(default));
        }

        [Test]
        public void WhenFindByDateTime_IfNotExistsElementWithDateTime_ShouldThrowException()
        {
            //Arrange
            var item = CreateReminderItem(messageDate: new DateTimeOffset(2007,9,1,00,00,00,TimeSpan.Zero));
            var storage = new ReminderStorage(item);

            //Act-Assert
            Assert.Catch<ArgumentException>(() => storage.FindByDateTime(new DateTimeOffset(2008,1,1,1,1,1,TimeSpan.Zero)));
        }

        [Test]
        public void WhenUpdate_IfNullSpecified_ShouldThrowException()
        {
            //Arrange
            var reminder = new ReminderStorage();

            //Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                reminder.Update(null));
        }

        [Test]
        public void WhenUpdate_IfNotExistElementWithKey_ShouldThrowException()
        {
            //Arrange
            var item = new ReminderItem(
                Guid.NewGuid(),
                "123",
                "Some text",
                DateTimeOffset.Now);
            var storage = new ReminderStorage();

            //Act-Assert
            Assert.Catch<ArgumentException>(() =>
                storage.Update(item));
        }

        private ReminderItem CreateReminderItem(
            Guid? id = default,
            string contactId = default,
            string message = default,
            DateTimeOffset? messageDate = default)
        {
            if (!id.HasValue)
            {
                id = Guid.NewGuid();
            }
            if (contactId == null)
            {
                contactId = "123";
            }
            if (message == null)
            {
                message = "Some text";
            }
            if (!messageDate.HasValue)
            {
                messageDate = DateTimeOffset.UtcNow;
            }
            return new ReminderItem(id.Value, contactId, message, messageDate.Value);
        }
    }
}