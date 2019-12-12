CREATE DATABASE PostOffice;
USE PostOffice;
GO

CREATE TABLE PostalSending
(
    [SenderName] [varchar](50),
    [ReceiverName] [varchar](50),
    [DocumentTitle] [varchar](30),
    [NumberOfPages] [smallint],
    [SendingDate] [datetimeoffset],
    [ExpectedReceivingDate] [datetimeoffset]
);

SELECT * FROM PostalSending;

INSERT INTO [dbo].[PostalSending] VALUES
 ('Man1','Man2','Document1', 20, '1912-10-25 12:24:32.1277 +10:0','1919-10-25 12:24:32.1277 +10:0'),
 ('Man2','Woman1','Document2', 108, '1812-10-25 12:24:32.1277 +10:0','1912-9-25 12:24:32.1277 +10:0');