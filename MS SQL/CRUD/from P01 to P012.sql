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

-- P13
SELECT 
TOP(5)   [FirstName],
         [LastName]
 FROM    [Employees]
ORDER BY [Salary] DESC

--P14
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE [DepartmentID] NOT IN (4)

--P15

  SELECT *
    FROM [Employees]
ORDER BY [Salary] DESC
		,[FirstName]
		,[LastName] DESC
		,[MiddleName]

		- Problem 17
-- Views store temporaly the SELECT query, not the resultset!!!
GO
 
CREATE VIEW [V_EmployeeNameJobTitle3]
         AS
            (
                SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
                    AS [Full Name],
                       [JobTitle]
                  FROM [Employees] 
            )
 
GO
 
SELECT * FROM [V_EmployeeNameJobTitle3]
 
GO
 
SELECT [FirstName] + ' ' + ISNULL([MiddleName], 'Replacement') + ' ' + [LastName]
                    AS [Full Name],
                       [JobTitle]
                  FROM [Employees] 
 
-- Problem 19
SELECT
TOP (10) *--, FORMAT([StartDate], 'dd/MM/yyyy')
    FROM [Projects]
ORDER BY [StartDate],
         [Name]
 
-- Problem 21
--Helper Queries
SELECT *
  FROM [Employees]
 
SELECT [DepartmentID]
  FROM [Departments]
 WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
 
--Main Query Solution
UPDATE [Employees]
   SET [Salary] += 0.12 * [Salary]
 WHERE [DepartmentID] IN (1, 2, 4, 11)
 
SELECT [Salary]
  FROM [Employees]
 
--You can use Reverse Query if the changed value is const
RESTORE DATABASE [SoftUni] FROM DISK = 'BackUpPath.bak'
 
-- Advanced Solution (Subqueries)
UPDATE [Employees]
   SET [Salary] += 0.12 * [Salary]
 WHERE [DepartmentID] IN 
                         (
                            SELECT [DepartmentID]
                              FROM [Departments]
                             WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
                         )
GO
 
USE [Geography]
GO
 
 
-- Problem 24
--CASE WHEN -> If [CurrencyCode] = 'EUR' then display 'Euro'
--             else display 'Not Euro'
  SELECT [CountryName],
         [CountryCode],
         CASE [CurrencyCode]
              WHEN 'EUR' THEN 'Euro'
              ELSE 'Not Euro'
         END
      AS [Currency]
    FROM [Countries]
ORDER BY [CountryName]


 








