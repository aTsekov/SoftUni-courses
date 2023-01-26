USE [SoftUni]
GO

--P01

SELECT [FirstName],[LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE ('Sa%')

 --P02
 SELECT [FirstName],[LastName] 
   FROM [Employees]
  WHERE [LastName] LIKE ('%ei%')

--P03

 SELECT [FirstName] 
   FROM [Employees]
  WHERE [DepartmentID] IN (3,10)AND
  YEAR([HireDate])BETWEEN 1995 AND 2005

--P04

 SELECT [FirstName],[LastName]
   FROM [Employees]
  WHERE [JobTitle] NOT LIKE '%engineer%'

--P05

 
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

--P06

 SELECT *
    FROM [Towns]
   WHERE LEFT([Name],1) IN ('M','K','B','E')
ORDER BY [Name]

--P07

 SELECT *
    FROM [Towns]
   WHERE LEFT([Name],1) NOT IN ('R','B','D')
ORDER BY [Name]

--P08


CREATE VIEW V_EmployeesHiredAfter2000
AS
     SELECT FirstName,
            LastName
     FROM Employees
     WHERE DATEPART(YEAR, HireDate) > 2000;

--P09

SELECT [FirstName],[LastName]
   FROM [Employees]
  WHERE LEN([LastName]) = 5;




  



   
