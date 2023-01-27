USE [SoftUni]
GO

-- Grouping Demo
  SELECT [JobTitle],
         AVG([Salary])
      AS [AverageSalary],
         COUNT([EmployeeID])
      AS [WorkersCount]
    FROM [Employees]
GROUP BY [JobTitle]
  HAVING AVG([Salary]) > 20000
--P01

SELECT TOP (5) [e].[EmployeeID],
           [e].[JobTitle],
           [e].[AddressID],
           [a].[AddressText] 
      FROM [Employees]
        AS [e]
INNER JOIN [Addresses]
        AS [a]
        ON [e].AddressID = [a].[AddressID]
  ORDER BY [e].[AddressID]