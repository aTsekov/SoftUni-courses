USE [SoftUni]
GO

-- P02

SELECT * FROM [Departments]

--P03

SELECT [Name] FROM [Departments]

-- P04

SELECT [FirstName],[LastName], [Salary] FROM Employees

-- P05

SELECT [FirstName],[MiddleName],[LastName] FROM Employees

-- P06

SELECT CONCAT([FirstName], '.', [MiddleName] + '.', [LastName], '@','softuni.bg') -- a '.' will be added after the 
--the middle name only if the middle name exists and it;s NOT NULL	  
	AS [Full Email Address]
  FROM [Employees]

-- P07
 SELECT DISTINCT [Salary] 
            FROM [Employees]

-- P08

SELECT * 
  FROM [Employees]
 WHERE [JobTitle] IN ('Sales Representative')

-- P09

SELECT [FirstName],[LastName],[JobTitle]
  FROM [Employees]
 WHERE [Salary] BETWEEN 20000 AND 30000

--P10
SELECT CONCAT([FirstName], ' ', [MiddleName] + ' ', [LastName])  
	AS [Full Name] 
  FROM [Employees]
 WHERE [Salary] IN(25000, 14000, 12500, 23600)

--P11
SELECT [FirstName],[LastName]
  FROM [Employees]
 WHERE [ManagerID] IS NULL

--P12

  SELECT [FirstName],[LastName],[Salary]
    FROM [Employees]
   WHERE [Salary]  >= 50000
ORDER BY [Salary] DESC
 








