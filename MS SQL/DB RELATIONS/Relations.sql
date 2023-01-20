CREATE DATABASE [Relations]
Use [Relations]

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
	