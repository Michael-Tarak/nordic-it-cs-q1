CREATE OR ALTER PROCEDURE sp_UpdateReminderItem (
	@p_id AS UNIQUEIDENTIFIER,
	@p_status AS TINYINT,
	@p_datetimeUtc AS DATETIMEOFFSET,
	@p_message AS NVARCHAR(2048)
)
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @updated BIT = 0;

	UPDATE [ReminderItem] SET
		[StatusId] = @p_status,
		[DatetimeUtc] = @p_datetimeUtc,
		[Message] = @p_message,
		[ModifiedDatetimeUtc] = SYSDATETIMEOFFSET(),
		@updated = 1
	WHERE [Id] = @p_id;

	SELECT @updated AS IsUpdated;
END
