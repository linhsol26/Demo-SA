IF OBJECT_ID('Song') IS NOT NULL DROP TABLE Song;
CREATE TABLE Song(
	Id int PRIMARY KEY IDENTITY,
	Title nvarchar(50) NOT NULL,
	Singer nvarchar(50) NOT NULL,
	Album nvarchar(50),
	Genre nvarchar(50) 
);	

INSERT INTO Song(Title, Singer, Album, Genre) VALUES ('Royals', 'Lorde', 'Pure Heroine', 'Alternative');
INSERT INTO Song(Title, Singer, Album, Genre) VALUES ('Team', 'Lorde', 'Pure Heroine', 'Alternative');
INSERT INTO Song(Title, Singer, Album, Genre) VALUES ('Blank Space', 'Taylor Swift', 'Single', 'Pop');
INSERT INTO Song(Title, Singer, Album, Genre) VALUES ('Angles Like You', 'Miley Cyrus', 'Plastic Hearts', '');

SELECT * FROM Song