IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Contact]') AND type in (N'U'))
	CREATE TABLE [Contact] (
		[Id] UNIQUEIDENTIFIER NOT NULL,
		[Login] VARCHAR(64),

		CONSTRAINT PK_Contact 
			PRIMARY KEY CLUSTERED ([Id]),

		CONSTRAINT UQ_ContactLogin 
			UNIQUE ([Login])
	);
