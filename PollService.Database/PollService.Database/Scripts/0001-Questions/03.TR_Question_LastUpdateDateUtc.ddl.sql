CREATE OR ALTER TRIGGER [dbo].[TR_Question_LastUpdateDateUtc]
ON [dbo].[Question]
AFTER UPDATE
AS
BEGIN
	UPDATE [Question]
	SET [LastUpdateDateUtc] = SYSDATETIMEOFFSET()
	FROM inserted
	WHERE [Question].[QuestionId] = inserted.[QuestionId]
END