CREATE TABLE [ReminderStorage]
(
    [Id] UNIQUEIDENTIFIER NOT NULL ,
    [ContactId] UNIQUEIDENTIFIER NOT NULL,
    [Message] VARCHAR(1024) NOT NULL,
    [Datetime] [datetimeoffset] NOT NULL,
    CONSTRAINT PK_ReminderStorage PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_ReminderStorage_ContactId FOREIGN KEY (ContactId)
        REFERENCES Contact(Id)
            ON DELETE CASCADE
            ON UPDATE CASCADE
);
GO

CREATE TABLE [Contact]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [FirstName] VARCHAR(128) NOT NULL,
    [LastName] VARCHAR(128) NOT NULL
    CONSTRAINT PK_Contact PRIMARY KEY CLUSTERED (Id)
);
GO