IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ReminderItem]') AND type in (N'U'))
	CREATE TABLE [ReminderItem] (
		[Id] UNIQUEIDENTIFIER NOT NULL,
		[ContactId] UNIQUEIDENTIFIER NOT NULL,
		[StatusId] TINYINT NOT NULL,
		[DatetimeUtc] DATETIMEOFFSET NOT NULL,
		[Message] NVARCHAR(2048) NOT NULL,
		[CreatedDatetimeUtc] DATETIMEOFFSET NOT NULL,
		[ModifiedDatetimeUtc] DATETIMEOFFSET NOT NULL,

		CONSTRAINT PK_ReminderItem 
			PRIMARY KEY CLUSTERED ([Id]),

		CONSTRAINT FK_ReminderItem_Contact 
			FOREIGN KEY ([ContactId]) REFERENCES [Contact]([Id])
				ON UPDATE CASCADE
				ON DELETE CASCADE,

		CONSTRAINT FK_ReminderItem_ReminderItemStatus
			FOREIGN KEY ([StatusId]) REFERENCES [ReminderItemStatus]([Id])
				ON UPDATE CASCADE
				ON DELETE CASCADE
	);
