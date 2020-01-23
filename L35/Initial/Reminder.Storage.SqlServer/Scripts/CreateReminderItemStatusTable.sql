IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ReminderItemStatus]') AND type in (N'U'))
	CREATE TABLE [ReminderItemStatus] (
		Id TINYINT NOT NULL,
		[Name] VARCHAR(16),

		CONSTRAINT PK_ReminderItemStatus 
			PRIMARY KEY CLUSTERED ([Id]),

		CONSTRAINT UQ_ReminderItemStatusName 
			UNIQUE ([Name])
	);
