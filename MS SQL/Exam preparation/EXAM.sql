CREATE DATABASE Boardgames
USE Boardgames

CREATE TABLE Categories 
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses 
(
 Id INT PRIMARY KEY IDENTITY,
 StreetName NVARCHAR(100) NOT NULL,
 StreetNumber INT NOT NULL,
 Town VARCHAR(30) NOT NULL,
 Country VARCHAR(50) NOT NULL,
 ZIP INT NOT NULL
)

CREATE TABLE Publishers 
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(30) UNIQUE NOT NULL,
 AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
 Website VARCHAR(40)  NULL,
 Phone VARCHAR(20)  NULL
)

CREATE TABLE PlayersRanges 
(
 Id INT PRIMARY KEY IDENTITY,
 PlayersMin INT NOT NULL,
 PlayersMax INT NOT NULL,
)


CREATE TABLE Boardgames 
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] NVARCHAR(30) NOT NULL,
 YearPublished INT NOT NULL,
 Rating DECIMAL (18,2)  NULL,
 CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
 PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
 PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL,
)

CREATE TABLE Creators 
(
 Id INT PRIMARY KEY IDENTITY,
 FirstName NVARCHAR(30) NOT NULL,
 LastName NVARCHAR(30) NOT NULL,
 Email NVARCHAR(30) NOT NULL
 )

 CREATE TABLE CreatorsBoardgames 
(
CreatorId INT FOREIGN KEY REFERENCES Creators(Id),
BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id),
PRIMARY KEY (CreatorId,BoardgameId)
)

--P02

INSERT INTO Boardgames ([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
       VALUES 
	   ('Deep Blue',2019,5.67,1,15,7),
	   ('Paris',2016,9.78,7,1,5),
	   ('Catan: Starfarers',2021,9.87,7,13,6),
	   ('Bleeding Kansas',2020,3.25,3,7,4),
	   ('One Small Step',2019,5.75,5,9,2)


	   INSERT INTO Publishers ([Name], AddressId, Website, Phone)
       VALUES 
	   ('Agman Games',5,'www.agmangames.com','+16546135542'),
	   ('Amethyst Games',7,'www.amethystgames.com','+15558889992'),
	   ('BattleBooks',13,'www.battlebooks.com','+12345678907')

--P03

UPDATE PlayersRanges
   SET PlayersMax = 3
 WHERE Id = 1

 UPDATE Boardgames
 SET [Name] = CONCAT([Name], 'V2')
 WHERE YearPublished >= 2020

--P04

SELECT * FROM Addresses
WHERE Country = 'USA'

SELECT* FROM Publishers
WHERE AddressId IN(1,2,4,7,8,9,11,12,13,14,15)

SELECT * FROM Boardgames
WHERE PublisherId IN(2,3,4,5,6,7,8,9,11,12,14)



SELECT * FROM Categories
WHERE Id IN(6,4,1)

SELECT * FROM CreatorsBoardgames --DONE
WHERE BoardgameId IN (1,16,31)

SELECT * FROM Creators
WHERE Id IN (1,2,3,4,5,6)

DELETE FROM Creators
WHERE Id IN (1,2,3,4,5,6)

DELETE FROM CreatorsBoardgames --DONE
WHERE BoardgameId IN (2,4,6,7,8,11,12,14,14,15,17,19,21,22,23,26,27,28,29,30,32,34,36,37,38,41,41,43,44,45)

DELETE FROM Boardgames
WHERE Id IN (2,4,6,7,8,11,12,14,14,15,17,19,21,22,23,26,27,28,29,30,32,34,36,37,38,41,41,43,44,45)

DELETE FROM Publishers
WHERE Id IN(2,3,4,5,6,7,8,9,11,12,14)

DELETE FROM Addresses
WHERE Id IN(1,2,4,7,8,9,11,12,13,14,15)






-- P05

SELECT [Name],Rating 
   FROM Boardgames
ORDER BY YearPublished, [Name] DESC

--P06 

SELECT b.Id,b.[Name],b.YearPublished,c.[Name] 
   FROM Boardgames
     AS b
   JOIN Categories
     AS c
	 ON c.Id = b.CategoryId
  WHERE c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC
	   
--P07

SELECT c.Id,CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,c.Email 
  FROM Creators
    AS c
LEFT JOIN Boardgames
       AS b
	   ON b.CategoryId = c.Id
 WHERE b.Id IS NULL
 ORDER BY CreatorName


 --P08

 SELECT TOP(5) b.[Name], b.Rating, c.[Name] AS CategoryName
   FROM Boardgames
     AS b
   JOIN Categories
     AS c
	 ON b.CategoryId = c.Id
   JOIN PlayersRanges
     AS p
	 ON p.Id = b.PlayersRangeId
WHERE (b.Rating > 7.00 AND b.[Name] LIKE '%a%') OR (b.Rating > 7.50 AND p.PlayersMin >= 2 AND p.PlayersMax <=5)
ORDER BY b.[Name], b.Rating DESC

--P09

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,c.Email, MAX(b.Rating) AS Rating
  FROM Creators
    AS c
  JOIN CreatorsBoardgames
    AS cb
	ON c.Id = cb.CreatorId
  JOIN Boardgames
    AS b
	ON b.Id = cb.BoardgameId
 WHERE c.Email LIKE '%.com%'
 GROUP BY CONCAT(c.FirstName, ' ', c.LastName),c.Email
 ORDER BY FullName

-- P10

    SELECT c.LastName, CEILING(AVG(b.Rating)) AS AverageRating, p.[Name] AS PublisherName
     FROM Creators
	   AS c
  JOIN CreatorsBoardgames
       AS cb
	   ON cb.CreatorId = c.Id
  JOIN Boardgames 
       AS b
	   ON b.Id = cb.BoardgameId
	  JOIN Publishers
	   AS p 
	   ON p.Id = b.PublisherId
    WHERE p.[Name] ='Stonemaier Games'
	GROUP BY c.LastName, p.[Name]
 ORDER BY AVG(b.Rating) DESC

 --P11

 GO
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR (30))
    RETURNS INT
             AS
          BEGIN
		   DECLARE @count INT;
		   SET @count = (
						SELECT COUNT(*) 
  FROM Creators
    AS c
  JOIN CreatorsBoardgames
       cb
	   ON cb.CreatorId = c.Id
	   WHERE c.[FirstName] = @name 
	                  )
					  IF @count IS NULL RETURN 0
					  RETURN @count
            END

			
 
GO
	--P12

GO
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
              AS
           BEGIN
                    SELECT b.[Name], YearPublished, Rating, c.[Name] AS CategoryName, 
		 p.[Name] AS PublisherName, CONCAT(pr.PlayersMin, ' people') AS MinPlayers, 
		 CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
    FROM Boardgames
	  AS b
	JOIN Categories
	  AS c
	  ON c.Id = b.CategoryId
	JOIN Publishers
	  AS p
	  ON p.Id = b.PublisherId
	JOIN PlayersRanges
	  AS pr
	  ON pr.Id = b.PlayersRangeId
   WHERE c.[Name] = @category
ORDER BY PublisherName, YearPublished  DESC
             END
 
GO

EXEC usp_SearchByCategory 'Wargames'

  SELECT b.[Name], YearPublished, Rating, c.[Name] AS CategoryName, 
		 p.[Name] AS PublisherName, CONCAT(pr.PlayersMin, ' people') AS MinPlayers, 
		 CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
    FROM Boardgames
	  AS b
	JOIN Categories
	  AS c
	  ON c.Id = b.CategoryId
	JOIN Publishers
	  AS p
	  ON p.Id = b.PublisherId
	JOIN PlayersRanges
	  AS pr
	  ON pr.Id = b.PlayersRangeId
   WHERE c.[Name] = 'Wargames'
ORDER BY PublisherName, YearPublished  DESC
    
