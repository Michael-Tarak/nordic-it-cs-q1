SELECT 
	RI.Id,
	C.Login,
	RI.Message,
	RI.DatetimeUtc,
	RI.StatusId
FROM [ReminderItem] RI
JOIN [Contact] C 
	ON RI.ContactId = C.Id
WHERE RI.Id = '{id}';