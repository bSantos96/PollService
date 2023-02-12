﻿IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Question')
BEGIN
	CREATE TABLE [Question]
	(
		[QuestionId] INT IDENTITY NOT NULL,
		[Question] VARCHAR(255),
		[ImageUrl] VARCHAR(255),
		[ThumbUrl] VARCHAR(255),
		[CreationDateUtc] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Question_CreationDateUtc] DEFAULT (SYSDATETIMEOFFSET()),
		[LastUpdateDateUtc] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Question_LastUpdateDateUtc] DEFAULT (SYSDATETIMEOFFSET()),
		CONSTRAINT [PK_QuestionId] PRIMARY KEY([QuestionId]),
	)
END