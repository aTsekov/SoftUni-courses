CREATE DATABASE Airport

USE Airport

--P01

CREATE TABLE Passengers 
(
		Id INT PRIMARY KEY IDENTITY,
		FullName VARCHAR(100) NOT NULL,
		Email VARCHAR (50) NOT NULL
)

CREATE TABLE Pilots 
(
		Id INT PRIMARY KEY IDENTITY,
		FirstName VARCHAR(30) NOT NULL,
		LastName VARCHAR(30) NOT NULL,
		Age TINYINT CHECK(Age >= 21 AND Age <= 62) NOT NULL,
		Rating FLOAT CHECK(Rating >= 0.0 AND Rating <= 10.0)
)

CREATE TABLE AircraftTypes 
(
		Id INT PRIMARY KEY IDENTITY,
		TypeName VARCHAR (30) NOT NULL
)

CREATE TABLE Aircraft 
(
		Id INT PRIMARY KEY IDENTITY,
		Manufacturer VARCHAR(25) NOT NULL,
		Model VARCHAR(30) NOT NULL,
		[Year] INT NOT NULL,
		FlightHours INT  NULL,
		Condition CHAR(1) NOT NULL,
		TypeId INT FOREIGN KEY REFERENCES AircraftTypes NOT NULL
		
)

CREATE TABLE PilotsAircraft
(
		AircraftId INT FOREIGN KEY REFERENCES Aircraft (Id) NOT NULL,
		PilotId INT FOREIGN KEY REFERENCES Pilots (Id) NOT NULL,
		PRIMARY KEY (AircraftId,PilotId)
)

CREATE TABLE Airports 
(
		Id INT PRIMARY KEY IDENTITY,
		AirportName VARCHAR(70) NOT NULL,
		Country VARCHAR(100) NOT NULL,		
)

CREATE TABLE FlightDestinations
(
		Id INT PRIMARY KEY IDENTITY,
		AirportId INT FOREIGN KEY REFERENCES Airports NOT NULL,
		Start DATETIME NOT NULL,
		AircraftId INT FOREIGN KEY REFERENCES Aircraft NOT NULL,
		PassengerId INT FOREIGN KEY REFERENCES Passengers NOT NULL,
		TicketPrice DECIMAL (18,2) DEFAULT 15 NOT NULL
)

--P02
INSERT INTO Passengers(FullName, Email)

SELECT CONCAT(FirstName,' ', LastName),
	   CONCAT(FirstName,'', LastName, '@gmail.com')
  FROM Pilots
 WHERE Id BETWEEN 5 AND 15

-- P03

UPDATE Aircraft
   SET Condition = 'A'
 WHERE Condition IN ('C','B') AND FlightHours IS NULL OR FlightHours <= 100 AND [Year] > 2013

--P04

DELETE  
 FROM Passengers
 WHERE LEN(FullName) <= 10

 --P05

  SELECT Manufacturer,Model,FlightHours,Condition 
    FROM Aircraft
ORDER BY FlightHours DESC

--P06

   SELECT p.FirstName,p.LastName, a.Manufacturer, a.Model,a.FlightHours
     FROM Pilots
       AS p
     JOIN PilotsAircraft
	   AS pa
	   ON p.Id = pa.PilotId
	 JOIN  Aircraft
	   AS a
	   ON a.Id = pa.AircraftId
    WHERE  FlightHours IS NOT NULL and FlightHours <= 304
 ORDER BY FlightHours DESC,
		  p.FirstName

--P07

   SELECT fl.Id AS DestinationId,fl.[Start],p.FullName,a.AirportName,fl.TicketPrice 
     FROM FlightDestinations
	   AS fl
 JOIN Passengers
       AS p
	   ON fl.PassengerId = p.Id
 JOIN Airports
       AS a
	   ON a.Id = fl.AirportId
    WHERE DATEPART(Day,fl.[Start]) % 2 = 0
 ORDER BY fl.TicketPrice DESC, a.AirportName

 --P08

 SELECT a.Id AS AircraftId, A.Manufacturer, a. FlightHours, 
  COUNT (f.Id) AS FlightDestinationsCount,
    AVG (f.TicketPrice) AS AvgPrice
   FROM Aircraft
     AS a
   JOIN FlightDestinations
     AS f
	 ON a.Id = f.AircraftId
GROUP BY a.Id, a.Manufacturer, A.FlightHours
HAVING COUNT (f.Id) >= 2
ORDER BY 4 DESC, 1

--P09

     SELECT p.FullName,
	  COUNT (a.Id) AS CountOfAircraft,
	  SUM (fd.TicketPrice) AS TotalPayed
	  FROM Passengers AS p
	  JOIN FlightDestinations AS fd ON p.Id = Fd.PassengerId
	  JOIN Aircraft AS a ON fd.AircraftId = a.Id
	  WHERE SUBSTRING(p.FullName, 2, 1) = 'a'
	  GROUP BY p.Id, p.FullName
	  HAVING COUNT (a.Id) >1
	  ORDER BY p.FullName

--P10

  SELECT a.AirportName,fd.Start AS DayTime, fd.TicketPrice, p.FullName, ar.Manufacturer,ar.Model
    FROM FlightDestinations
      AS fd
    JOIN Airports
      AS a
      ON fd.AirportId = a.Id
    JOIN Passengers
      AS p
   	  ON p.Id = fd.PassengerId
    JOIN Aircraft 
      AS ar
   	  ON ar.Id = fd.AircraftId
   WHERE DATEPART(HOUR, fd.[Start]) >= 6.00 AND DATEPART(HOUR, fd.[Start]) <= 20.00 AND fd.TicketPrice > 2500
ORDER BY ar.Model 

--P11
GO
CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR (50))
    RETURNS INT
             AS
          BEGIN
		   DECLARE @num INT;
		   SET @num = (
						SELECT COUNT(*) 
						  FROM Passengers
	                        AS p
	                      JOIN FlightDestinations
	                        AS fl
	                    	ON fl.PassengerId = p.Id
	                     WHERE p.Email = @email
	                  GROUP BY p.Email  
	                  )
					  IF @num IS NULL RETURN 0
					  RETURN @num
            END

			
 
GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
			SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
			SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')
    
	--P12

GO
CREATE PROCEDURE usp_SearchByAirportName (@airportName VARCHAR(70))
              AS
           BEGIN
                     SELECT AirportName, pa.FullName, 
		CASE
		WHEN fd.TicketPrice <= 400 THEN 'Low'
		WHEN fd.TicketPrice > 400 AND fd.TicketPrice <= 1500 THEN 'Medium'
		WHEN fd.TicketPrice > 1500 THEN 'High'
		END
		AS LevelOfTickerPrice,
		ac.Manufacturer, 
		ac.Condition, [at].TypeName
		FROM Airports AS ap
		JOIN FlightDestinations AS fd ON ap.Id = fd.AirportId
		JOIN Passengers AS pa ON fd.PassengerId = pa.Id
		JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
		JOIN AircraftTypes as [at] ON ac.TypeId = [at].Id
		WHERE AirportName = @airportName
		ORDER BY ac.Manufacturer, pa.FullName
             END
 
GO


EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'