IF NOT EXISTS (SELECT [Id] FROM [ReminderItemStatus] WHERE [Id] > 0)
	INSERT INTO [ReminderItemStatus] ([Id], [Name])
		VALUES (1, 'Created'),
			   (2, 'Ready'),
			   (3, 'Sent'),
			   (4, 'Failed');
