--P1

CREATE DATABASE NationalTouristSitesOfBulgaria
USE NationalTouristSitesOfBulgaria

CREATE TABLE Categories(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE Locations(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL,
 Municipality VARCHAR(50), 
 Province VARCHAR(50)
);

CREATE TABLE Sites(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(100) NOT NULL,
 LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL , 
 CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
 Establishment VARCHAR(15)
);

CREATE TABLE Tourists(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL,
 Age INT  CHECK (Age >= 0 AND Age <= 120) NOT NULL,
 PhoneNumber VARCHAR(20) NOT NULL,
 Nationality VARCHAR(30) NOT NULL,
 Reward VARCHAR(20)

);

CREATE TABLE SitesTourists(
 TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
 SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL,
 PRIMARY KEY (TouristId,SiteId) 

);

CREATE TABLE BonusPrizes(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE TouristsBonusPrizes(
 TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
 BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL,
 PRIMARY KEY (TouristId,BonusPrizeId) 

);

-- P02

INSERT INTO Tourists ([Name],Age,PhoneNumber,Nationality,Reward)
VALUES
('Borislava Kazakova',52,'+359896354244','Bulgaria', NULL),
('Peter Bosh',48,'+447911844141','UK', NULL),
('Martin Smith',29,'+353863818592','Ireland', 'Bronze badge'),
('Svilen Dobrev',49,'+359986584786','Bulgaria', 'Silver badge'),
('Kremena Popova',38,'+359893298604','Bulgaria', NULL)


INSERT INTO Sites ([Name],LocationId,CategoryId,Establishment)
VALUES
('Ustra fortress',90,7,'X'),
('Karlanovo Pyramids',65,7, NULL),
('The Tomb of Tsar Sevt',63,8, 'V BC'),
('Sinite Kamani Natural Park',17,1, NULL),
('St. Petka of Bulgaria – Rupite',92,6, '1994')

--P03

UPDATE Sites
   SET Establishment = '(not defined)'
WHERE Establishment IS NULL

--P04

DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = (
							SELECT Id
							  FROM BonusPrizes
							 WHERE [Name] = 'Sleeping bag'						
					 )
DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'

--P05

  SELECT [Name],Age,PhoneNumber,Nationality
    FROM Tourists
ORDER BY Nationality,
		 Age DESC,
		 [Name]

--P06

   SELECT s.[Name],l.[Name],s.Establishment,c.[Name] 
     FROM Locations
       AS l
 JOIN Sites
       AS s
	   ON l.Id = s.LocationId
 JOIN Categories
       AS c
	   ON c.Id = s.CategoryId
 ORDER BY c.[Name] DESC,
		  l.[Name],
		  s.[Name]

--P07

SELECT  l.Province,
		l.Municipality,
		l.[Name] AS  [Location],
		COUNT(s.[Name]) AS CountOfSites		
  FROM Sites
    AS s
LEFT JOIN Locations
	   AS l
	   ON s.LocationId = l.Id
	WHERE l.Province = 'Sofia'
GROUP BY  l.[Name],l.Municipality,l.Province
ORDER BY  CountOfSites DESC,
		  l.[Name]

--P08

   SELECT s.[Name]
	   AS Site,
		  l.[Name]
	   AS [Location],
	      l.Municipality,
		  l.Province,
		  s.Establishment
     FROM Sites
       AS s
     JOIN Locations
       AS l
	   ON s.LocationId = l.Id
    WHERE LEFT(l.[Name],1) NOT IN ('B','M','D') AND s.Establishment LIKE '%BC'--RIGHT(s.Establishment, 1) IN ('C')
 ORDER BY s.[Name]

