CREATE DATABASE [Movies]
Use [Movies]

CREATE TABLE [Directors] (
	Id INT PRIMARY KEY,
	DirectorName VARCHAR(50),
	Notes VARCHAR(MAX)
);

CREATE TABLE [Genres] (
	Id INT PRIMARY KEY,
	GenreName VARCHAR(20),
	Notes VARCHAR(MAX)
);

CREATE TABLE [Categories] (
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(20),
	Notes VARCHAR(MAX)
);

CREATE TABLE [Movies] (
	Id INT PRIMARY KEY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] DECIMAL (15,2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating TINYINT NOT NULL,	
	Notes VARCHAR(MAX)
);

INSERT INTO [Directors]
VALUES
(1,'Gosho','Test1'),
(2,'Gosho1','Test2'),
(3,'Gosho2','Test3'),
(4,'Gosho3','Test4'),
(5,'Gosho4','Test5')

INSERT INTO [Genres]
VALUES
(1,'Comedy','Test1'),
(2,'Comedy1','Test2'),
(3,'Comedy2','Test3'),
(4,'Comedy3','Test4'),
(5,'Comedy4','Test5')

INSERT INTO [Categories]
VALUES
(1,'Comedy','Test1'),
(2,'Comedy1','Test2'),
(3,'Comedy2','Test3'),
(4,'Comedy3','Test4'),
(5,'Comedy4','Test5')

INSERT INTO [Movies]
VALUES
(1,'Friends1',11,'2022-09-15', '2.46',11,131,1,'Notes1'),
(2,'Friends2',22,'2022-09-15', '2.46',23,141,2,'Notes1'),
(3,'Friends3',33,'2022-09-15', '2.46',43,151,3,'Notes1'),
(4,'Friends4',44,'2022-09-15', '2.46',45,161,4,'Notes1'),
(5,'Friends5',55,'2022-09-15', '2.46',56,171,5,'Notes1')