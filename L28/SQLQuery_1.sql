CREATE TABLE [Products]
(
    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY CLUSTERED,
    [CategoryId] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](256) NOT NULL
);
GO

ALTER TABLE [Products]
    ADD CONSTRAINT [FK_Category_Id] FOREIGN KEY ([CategoryId])
    REFERENCES [Category]([Id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

-- Select rows from a Table or View '[[Products]]' in schema '
SELECT * FROM [Products];
SELECT * FROM [Category];

GO

INSERT INTO [Products] ([Id],[CategoryId], [Name])
VALUES (NEWID(), 'c7aba396-aee7-4eaf-b54c-f32f591343d1', 'Mac');

DECLARE @CategoryId [uniqueidentifier] = 'c7aba396-aee7-4eaf-b54c-f32f591343d1';
PRINT 'The value is ' + COALESCE(CONVERT(VARCHAR(64),@CategoryId),'NULL');