CREATE OR ALTER PROCEDURE sp_AddReminderItem (
	@p_id AS UNIQUEIDENTIFIER,
	@p_contact AS VARCHAR(64),
	@p_status AS TINYINT,
	@p_datetimeUtc AS DATETIMEOFFSET,
	@p_message AS NVARCHAR(2048)
)
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE 
		@now AS DATETIMEOFFSET,
		@contactId AS UNIQUEIDENTIFIER;

	SET @now = SYSDATETIMEOFFSET();
	SELECT @contactId=[Id] FROM [Contact] WHERE [Login] = @p_contact;
	IF @contactId IS NULL
	BEGIN
		SET @contactId = NEWID();
		INSERT INTO [Contact]([Id], [Login]) VALUES (@contactId, @p_contact);
	END

	INSERT INTO [ReminderItem]([Id], [ContactId], [StatusId], [DatetimeUtc], [Message], [CreatedDatetimeUtc], [ModifiedDatetimeUtc])
		VALUES (@p_id, @contactId, @p_status, @p_datetimeUtc, @p_message, @now, @now);
END