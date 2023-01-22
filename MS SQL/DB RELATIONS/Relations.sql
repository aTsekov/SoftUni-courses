CREATE DATABASE [Relations]
Use [Relations]

-- P01 ONE TO ONE
CREATE TABLE [Passports] 
(
	[PassportID] INT PRIMARY KEY IDENTITY(101,1),
	[PassportNumber] CHAR(30)
)

CREATE TABLE [Persons]
(
	[PersonID] INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] VARCHAR(50),
	[Salary] DECIMAL(8,2),
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
-- In 1 to 1 relations the Foreign key must be unique. (The passport of each person is unique.)
)

INSERT INTO [Passports] ([PassportNumber])
VALUES
	 ('N34FG21B'),
	 ('K65LO4R7'),
	 ('ZE657QP2')

INSERT INTO [PERSONS] ([FirstName],[Salary],[PassportID])
VALUES
	 ('Roberto',43300.00,102),
	 ('Tom',56100.00,103),
	 ('Yana',60200.00,101)

--P02 ONE TO MANY


CREATE TABLE [Manufacturers]
(
	[ManufacturerID] INT PRIMARY KEY,
	[Name] CHAR (50) NOT NULL,
	[EstablishedOn] DATETIME2 NOT NULL

)

CREATE TABLE [Models]
(
	[ModelID] INT PRIMARY KEY IDENTITY (101,1),
	[Name] CHAR (50) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO [Manufacturers]
VALUES 
	 (1,'BMW','07/03/1916'),
	 (2,'Tesla','01/01/2003'),
	 (3,'Lada','01/05/1966')
	
INSERT INTO [Models]
VALUES 
	 ('X1',1),
	 ('i6',1),
	 ('Model S',2),
	 ('Model X',2),
	 ('Model 3',2),
	 ('Nova',3)

--P03 RELATION MANY TO MANY

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50)
)

CREATE TABLE [Exams]
(
	[ExamID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50)
)

CREATE TABLE [StudentsExams] -- In this table we set 2 FK and make a composite PK containing the 2 FKs. 
--This way the relation MANY TO MANY is created and the PK in this table ensures the uniuqness of the combinations.
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students] ([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES [Exams] ([ExamID]),
	PRIMARY KEY ([StudentID],[ExamID]) 
)


INSERT INTO[Students]([Name])
VALUES 
('Mila'),
('Toni'),
('Ron')

INSERT INTO[Exams]([Name])
VALUES 
('SpringMVC'),
('Neo4j'),
('Oracle 11g')


INSERT INTO[StudentsExams]([StudentID],[ExamID])
VALUES 
(1,101),
(1,102),
(2,101)


--P04 SELF-REFERENCING

CREATE TABLE [Teachers]

(
	[TeacherID] INT PRIMARY KEY IDENTITY (101,1),
	[Name] NVARCHAR (50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers] ([TeacherID]) -- A manager can have multiple teachers beneth. 
	--Since the PK and FK are in the same table we need to think which one is higher level and this one will be the FK. 
)

INSERT INTO[Teachers]([Name],[ManagerID])
VALUES 
('John', NULL ),
('Maya',106 ),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)



-- P05 Online Store Database

CREATE DATABASE [Store Datebase]

USE [Store Datebase]


CREATE TABLE [Cities]
(
	[CityID] INT PRIMARY KEY IDENTITY (1,1),
	[Name] NVARCHAR (50)
)

CREATE TABLE [Customers]
(
	[CustomerID] INT PRIMARY KEY IDENTITY (1,1),
	[Name] NVARCHAR (50),
	[Birthday] DATETIME2,
	[CityID] INT FOREIGN KEY REFERENCES [Cities](CityID)
)

CREATE TABLE [Orders]
(
	[OrderID] INT PRIMARY KEY IDENTITY (1,1),	
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [ItemTypes]
(
	[ItemTypeID] INT PRIMARY KEY IDENTITY (1,1),
	[Name] NVARCHAR (50)

)

CREATE TABLE [Items]
(
	[ItemID] INT PRIMARY KEY IDENTITY (1,1),
	[Name] NVARCHAR (50),
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [OrderItems]
(
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]),	
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]),
	PRIMARY KEY ([OrderID],[ItemID])
)














	 