﻿CREATE OR ALTER PROCEDURE sp_DeleteReminderItem (
	@p_id AS UNIQUEIDENTIFIER
)
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @deleted TABLE (
		Id UNIQUEIDENTIFIER
	);

	DELETE FROM [ReminderItem] 
	OUTPUT DELETED.Id INTO @deleted 
	WHERE Id = @p_id;
	
	SELECT COUNT(Id) AS [DeletedCount] FROM @deleted;
END
