using System;
using System.Linq;
using NUnit.Framework;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.SqlServer.Tests
{
	public class ReminderStorageTests
	{
		private const string ConnectionString = "Server=tcp:shadow-art.database.windows.net,1433;Initial Catalog=reminder; Persist Security Info=False;User ID=app_testing@shadow-art;Password=XCrzJjTRqX43uzaEpJNj;Encrypt=True;";

		private ReminderStorageInitializer Initializer { get; } =
			new ReminderStorageInitializer(ConnectionString);

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			Initializer.CreateTables();
			Initializer.CreateStoredProcedures();
		}

		[OneTimeTearDown]
		public void OneTimeTeardown()
		{
			Initializer.DropStoredProcedures();
			Initializer.DropTables();
		}

		[Test]
		public void WhenFindBy_IfItemExists_ShouldReturnsMatchedResults()
		{
			// Arrange
			var datetime = DateTimeOffset.UtcNow.AddDays(-2);
			var status = ReminderItemStatus.Ready;
			var storage = Create
				.Storage(ConnectionString)
				.WithItems(
					Create.Item(status: status, datetime: datetime),
					Create.Item(status: status, datetime: datetime),
					Create.Item(status: status, datetime: datetime),
					Create.Item(status: status, datetime: datetime),
					Create.Item(status: ReminderItemStatus.Sent, datetime: datetime),
					Create.Item(status: ReminderItemStatus.Ready, datetime: datetime.AddDays(1))
				)
				.Build();
			var filter = new ReminderItemFilter(new PageInfo(2, 2), datetime.AddMinutes(1), status);

			// Act
			var result = storage.FindBy(filter);

			// Assert
			Assert.AreEqual(4, result.Total);
			Assert.AreEqual(2, result.Page.Number);
			Assert.AreEqual(2, result.Items.Count);
		}

		[Test]
		public void WhenFindById_IfItemNotExists_ShouldThrow()
		{
			// Arrange
			var storage = Create
				.Storage(ConnectionString)
				.Build();

			// Act-Assert
			Assert.Throws<ReminderItemNotFoundException>(
				() => storage.FindById(Guid.NewGuid())
			);
		}

		[Test]
		public void WhenFindById_IfItemExists_ShouldRetun()
		{
			// Arrange
			var id = Guid.NewGuid();
			var storage = Create
				.Storage(ConnectionString)
				.WithItems(Create.Item(id))
				.Build();

			// Act
			var item = storage.FindById(id);

			// Assert
			Assert.AreEqual(id, item.Id);
		}

		[Test]
		public void WhenAdd_IfEmptyStorage_ShouldFindItemById()
		{
			// Arrange
			var id = Guid.NewGuid();
			var storage = Create
				.Storage(ConnectionString)
				.Build();

			// Act
			storage.Add(Create.Item(id));

			// Assert
			var result = storage.FindById(id);
			Assert.AreEqual(id, result.Id);
		}

		[Test]
		public void WhenAdd_IfItemAlreadyExists_ShouldThrow()
		{
			// Arrage
			var id = Guid.NewGuid();
			var storage = Create
				.Storage(ConnectionString)
				.WithItems(Create.Item(id: id))
				.Build();

			// Act-Assert
			Assert.Throws<ReminderItemDuplicateException>(
				() => storage.Add(Create.Item(id))
			);
		}

		[Test]
		public void WhenUpdate_IfItemNotExists_ShouldThrow()
		{
			// Arrage
			var id = Guid.NewGuid();
			var storage = Create
				.Storage(ConnectionString)
				.Build();

			// Act-Assert
			Assert.Throws<ReminderItemNotFoundException>(
				() => storage.Update(Create.Item(id))
			);
		}

		[Test]
		public void WhenUpdate_IfItemExists_ShouldUpdate()
		{
			// Arrange
			var id = Guid.NewGuid();
			var storage = Create
				.Storage(ConnectionString)
				.WithItems(Create.Item(id: id, message: "Old message"))
				.Build();

			// Act 
			storage.Update(Create.Item(id, message: "New message"));

			// Assert
			var item = storage.FindById(id);
			Assert.AreEqual(id, item.Id);
			Assert.AreEqual("New message", item.Message);
		}

		[Test]
		public void WhenDelete_IfItemNotExists_ShouldThrow()
		{
			// Arrage
			var storage = Create
				.Storage(ConnectionString)
				.Build();

			// Act-Assert
			Assert.Throws<ReminderItemNotFoundException>(
				() => storage.Delete(Guid.NewGuid())
			);
		}

		[Test]
		public void WhenDelete_IfItemExists_ShouldNotFoundInResults()
		{
			// Arrage
			var id = Guid.NewGuid();
			var storage = Create
				.Storage(ConnectionString)
				.WithItems(Create.Item(id))
				.Build();

			// Act
			storage.Delete(id);

			var page = storage.FindBy(
				new ReminderItemFilter()
			);
			Assert.IsNull(page.Items.FirstOrDefault(_ => _.Id == id));
		}
	}
}
