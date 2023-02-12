IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Answer')
BEGIN
	INSERT INTO [Answer] (
		[QuestionId],
		[Answer],
		[Votes]
	)
	VALUES
		(1, 'Swift', 2048), (1, 'Python', 1024), (1, 'Objective-C', 512), (1, 'Ruby', 256),
		(2, 'Rap', 2048), (2, 'Fado', 1024), (2, 'R&B', 512), (2, 'Rock', 256),
		(3, 'East', 2048), (3, 'West', 1024)
END