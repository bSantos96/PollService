CREATE OR ALTER TRIGGER [dbo].[TR_Answer_LastUpdateDateUtc]
ON [dbo].[Answer]
AFTER UPDATE
AS
BEGIN
	UPDATE [Answer]
	SET [LastUpdateDateUtc] = SYSDATETIMEOFFSET()
	FROM inserted
	WHERE [Answer].[AnswerId] = inserted.[AnswerId]
END