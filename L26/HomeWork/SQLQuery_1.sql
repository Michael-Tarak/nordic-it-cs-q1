CREATE TABLE [Category] (
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

INSERT Category ([id],[Name]) VALUES (NEWID(), 'Laptop');

SELECT * FROM [Category];

UPDATE [Category]
    SET [Name] = 'Tablet'
WHERE [Id] = 'b18e0d16-fe26-4f37-ac08-3ad20a47fd67';

-- Create a nonclustered index with or without a unique constraint
-- Or create a clustered index on table '[Category]' in schema '[m_tarakanov]' in database '[reminder]'
CREATE UNIQUE INDEX UX_Table_Name ON [Category] ([Name] DESC) /*Change sort order as needed*/

SELECT
 * 
FROM [Category]
ORDER BY [Name] DESC
OFFSET 4 ROWS
FETCH NEXT 1 ROWS ONLY;

-- Select rows from a Table or View '[Category]' in schema '
SELECT * FROM [Category]
WHERE [Name] LIKE '%A%'
GO