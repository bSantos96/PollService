IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Answer')
BEGIN
	CREATE TABLE [Answer]
	(
		[AnswerId] INT IDENTITY NOT NULL,
		[QuestionId] INT NOT NULL,
		[Answer] VARCHAR(255),
		[Votes] INT NOT NULL CONSTRAINT [DF_Answer_Votes] DEFAULT(0),
		[CreationDateUtc] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Answer_CreationDateUtc] DEFAULT (SYSDATETIMEOFFSET()),
		[LastUpdateDateUtc] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Answer_LastUpdateDateUtc] DEFAULT (SYSDATETIMEOFFSET()),
		CONSTRAINT [PK_AnswerId] PRIMARY KEY([AnswerId]),
		CONSTRAINT [FK_Answer_QuestionId_Question] FOREIGN KEY([QuestionId]) REFERENCES [Question],
	)
END