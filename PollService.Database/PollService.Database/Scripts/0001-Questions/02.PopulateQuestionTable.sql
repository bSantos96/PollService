IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Question')
BEGIN
	INSERT INTO Question (
		[Question],
		[ImageUrl],
		[ThumbUrl]
	)
	VALUES
		('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)'),
		('Favourite music genre?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)'),
		('Who wins the 2023 NBA All-Star Game?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)')
END