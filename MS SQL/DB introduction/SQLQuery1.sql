CREATE DATABASE [Minions] -- Create DB

USE [Minions]

CREATE TABLE Minions( --Create a Table with the following fields
Id INT,
[Name] NVARCHAR(100),
Age INT
);

CREATE TABLE Towns ( --Create a Table with the following fields
Id INT PRIMARY KEY , -- NOT NULL BY DEFAULT,
[Name] VARCHAR (100)

);

ALTER TABLE Minions --Change the table and make a Joint between the two tables by using the second's table PK
ADD[TownId] INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Towns --Insert data in the fields
 VALUES
 (1,'Sofia'),
 (2,'Plovdiv'), 
 (3,'Varna')

INSERT INTO Minions
(Id,[Name],Age,TownId)
VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

Select * FROM [Minions]
Select * FROM [Towns]

TRUNCATE  TABLE [Minions]
Drop TABLE Minions
Drop TABLE Towns



