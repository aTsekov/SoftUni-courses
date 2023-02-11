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