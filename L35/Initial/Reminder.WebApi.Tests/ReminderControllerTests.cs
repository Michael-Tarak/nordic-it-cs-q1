using System;
using NUnit.Framework;
using Reminder.Storage;
using Reminder.Storage.Exceptions;

namespace Reminder.WebApi.Tests
{
	public class ReminderWebApiTests
	{
		private ReminderWebApiFactory DefaultFactory =>
			new ReminderWebApiFactory();

		[Test]
		public void WhenFindById_IfItemNotExists_ShouldThrow()
		{
			// Arrange
			var storage = DefaultFactory.CreateReminderClient();

			// Act-Assert
			Assert.Catch<ReminderItemNotFoundException>(() =>
				storage.FindById(Guid.NewGuid())
			);
		}

		[Test]
		public void WhenFindById_IfItemExists_ShouldReturn()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var factory = new ReminderWebApiFactory(
				CreateReminderItem(id: itemId)
			);
			var storage = factory.CreateReminderClient();

			// Act
			var actual = storage.FindById(itemId);

			// Assert
			Assert.AreEqual(itemId, actual.Id);
		}

		[Test]
		public void WhenFindBy_IfItemsNotExists_WhouldReturnEmptyResult()
		{
			// Arrange
			var storage = DefaultFactory.CreateReminderClient();

			// Act
			var result = storage.FindBy(
				new ReminderItemFilter(page: new PageInfo(size: 100))
			);

			// Assert
			Assert.AreEqual(0, result.Total);
		}

		[TestCase(ReminderItemStatus.Undefied, "", 1u, 10u, 6, 6)]
		[TestCase(ReminderItemStatus.Undefied, "", 2u, 3u, 6, 3)]
		[TestCase(ReminderItemStatus.Undefied, "", 2u, 10u, 6, 0)]
		[TestCase(ReminderItemStatus.Created, "", 1u, 10u, 2, 2)]
		[TestCase(ReminderItemStatus.Created, "now", 1u, 10u, 1, 1)]
		[TestCase(ReminderItemStatus.Created, "", 2u, 1u, 2, 1)]
		public void WhenFindBy_IfStatusAndDatetimeSpecified_ShouldReturnFilteredResults(
			ReminderItemStatus status,
			string datetimeUtc,
			uint pageNumber,
			uint pageSize,
			int expectedTotal,
			int expectedItemsCount)
		{
			// Arrange
			var factory = new ReminderWebApiFactory(
				CreateReminderItem(status: ReminderItemStatus.Created, datetimeUtc: DateTimeOffset.UtcNow),
				CreateReminderItem(status: ReminderItemStatus.Created, datetimeUtc: DateTimeOffset.UtcNow.AddHours(1)),
				CreateReminderItem(status: ReminderItemStatus.Ready, datetimeUtc: DateTimeOffset.UtcNow),
				CreateReminderItem(status: ReminderItemStatus.Ready, datetimeUtc: DateTimeOffset.UtcNow.AddHours(1)),
				CreateReminderItem(status: ReminderItemStatus.Sent, datetimeUtc: DateTimeOffset.UtcNow.AddHours(-1)),
				CreateReminderItem(status: ReminderItemStatus.Failed, datetimeUtc: DateTimeOffset.UtcNow.AddHours(-1))
			);
			var storage = factory.CreateReminderClient();

			// Act
			var filter = new ReminderItemFilter(
				page: new PageInfo(pageNumber, pageSize),
				status: status,
				datetimeUtc: (datetimeUtc == "now") ? DateTimeOffset.UtcNow : default
			);
			var result = storage.FindBy(filter);

			// Assert
			Assert.AreEqual(expectedTotal, result.Total);
			Assert.AreEqual(expectedItemsCount, result.Items.Count);
			Assert.AreEqual(filter.Page.Number, result.Page.Number);
			Assert.AreEqual(filter.Page.Size, result.Page.Size);
		}

		[Test]
		public void WhenCreate_IfSpecifiedValidBody_ShouldReturnResult()
		{
			// Arrange
			var storage = DefaultFactory.CreateReminderClient();

			// Act
			var item = CreateReminderItem();
			storage.Add(item);

			// Assert
			var actualItem = storage.FindById(item.Id);
			Assert.AreEqual(item, actualItem);
		}

		[Test]
		public void WhenCreate_IfItemExists_ShouldThrow()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var factory = new ReminderWebApiFactory(
				CreateReminderItem(id: itemId)
			);
			var storage = factory.CreateReminderClient();

			// Act-Assert
			Assert.Catch<ReminderItemDuplicateException>(() =>
				storage.Add(
					CreateReminderItem(id: itemId)
				)
			);
		}

		[Test]
		public void WhenUpdate_IfItemNotExists_ShouldThrow()
		{
			// Arrange
			var storage = DefaultFactory.CreateReminderClient();

			// Act-Assert
			Assert.Catch<ReminderItemNotFoundException>(() =>
				storage.Update(
					CreateReminderItem()
				)
			);
		}

		[Test]
		public void WhenUpdate_ItItemExists_ShouldReturnUpdatedItem()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var factory = new ReminderWebApiFactory(
				CreateReminderItem(id: itemId, message: "Old message")
			);
			var storage = factory.CreateReminderClient();

			// Act
			storage.Update(
				CreateReminderItem(id: itemId, message: "Updated message")
			);

			// Assert
			var actual = storage.FindById(itemId);
			Assert.AreEqual("Updated message", actual.Message);
		}

		[Test]
		public void WhenDelete_IfItemNotExists_ShouldThrow()
		{
			// Arrange
			var storage = DefaultFactory.CreateReminderClient();

			// Act-Assert
			Assert.Catch<ReminderItemNotFoundException>(() =>
				storage.Delete(
					Guid.NewGuid()
				)
			);
		}

		[Test]
		public void WhenDelete_IfItemExists_ShouldDelete()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var factory = new ReminderWebApiFactory(
				CreateReminderItem(id: itemId)
			);
			var storage = factory.CreateReminderClient();

			// Act
			storage.Delete(itemId);

			// Assert
			Assert.Catch<ReminderItemNotFoundException>(() =>
				storage.FindById(itemId)
			);
		}

		private ReminderItem CreateReminderItem(
			Guid? id = default,
			string contactId = default,
			string message = default,
			DateTimeOffset? datetimeUtc = default,
			ReminderItemStatus? status = default)
		{
			return new ReminderItem(
				id ?? Guid.NewGuid(),
				contactId ?? "contactid",
				message ?? "message",
				datetimeUtc ?? DateTimeOffset.UtcNow,
				status ?? ReminderItemStatus.Created);
		}
	}
}