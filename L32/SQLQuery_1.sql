CREATE TABLE [ReminderItemStatus] (
    [Id] TINYINT NOT NULL,
    [Name] VARCHAR (32) NOT NULL,

    CONSTRAINT [PK_ReminderItemStatus] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_ReminderItemStatus_Name] UNIQUE ([Name])

);

CREATE TABLE [Contact] (
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Login] VARCHAR(64) NOT NULL,
    CONSTRAINT PK_Contact PRIMARY KEY ([Id]),
    CONSTRAINT UQ_Contact_Login UNIQUE ([Login])
);

CREATE TABLE [ReminderItem] (
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [ContactId] UNIQUEIDENTIFIER NOT NULL,
    [StatusId] TINYINT NOT NULL,
    [DatetimeUtc] DATETIMEOFFSET NOT NULL,
    [Message] NVARCHAR(2048),
    [CreateDatetimeUtc] DATETIMEOFFSET NOT NULL,
    [ModifiedDatetimeUtc] DATETIMEOFFSET NOT NULL,
    CONSTRAINT PK_ReminderItem PRIMARY KEY ([Id]),
    CONSTRAINT FK_ReminderItem_Contact FOREIGN KEY ([ContactId]) REFERENCES Contact([Id])
    ON UPDATE CASCADE
    ON DELETE CASCADE,
    
);

INSERT INTO [ReminderItemStatus] ([Id], [Name]) VALUES
    (1,'Created'),
    (2,'Ready'),
    (3,'Sent'),
    (4,'Failed');