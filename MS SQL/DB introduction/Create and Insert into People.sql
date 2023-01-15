CREATE DATABASE [People] -- Create DB

USE [People]


CREATE TABLE People(
Id BIGINT PRIMARY KEY IDENTITY , -- NOT NULL BY DEFAULT,
[Name] NVARCHAR (200) NOT NULL,
Picture VARBINARY (2000),
Height DECIMAL (5,2) ,
[Weight] DECIMAL (5,2) ,
Gender CHAR(2) CHECK (gender in ('f','m') ) NOT NULL, --Check if Gender is f or m
Birthdate DATETIME2 NOT NULL ,
BIOGRAPHY NVARCHAR(MAX)
);

INSERT INTO People
VALUES	
	('Petar1',NULL ,'156.6','86.4','m','10-10-1994','TEST1'),
	('Petar2',NULL ,'166.6','87.4','f','10-10-1995','TEST2'),
	('Petar3',NULL ,'176.6','88.4','m','10-10-1996','TEST3'),
	('Petar4',NULL ,'186.6','89.4','f','10-10-1997','TEST4'),
	('Petar5',NULL ,'196.6','82.4','m','10-10-1991','TEST5')


	SELECT * FROm People