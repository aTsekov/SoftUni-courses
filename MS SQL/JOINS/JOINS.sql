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

--P02

SELECT TOP (50)[e].[FirstName],[e].[LastName],[t].[Name] AS [Town],[a].[AddressText] 
      FROM [Employees]
        AS [e]
      JOIN [Addresses]
        AS [a]
	    ON [e].[AddressID] = [a].[AddressID]
 LEFT JOIN [Towns]
   	    AS [t]
	    ON [a].[TownID] = [t].[TownID]
  ORDER BY [e].[FirstName],[e].[LastName]

--P03
SELECT [e].[EmployeeID], [e].[FirstName], [e].[LastName], [d].[Name] AS [DepartmentName]
  FROM [Employees]
	AS [e]
  JOIN [Departments]
	AS [d]
	ON [e].DepartmentID = [d].DepartmentID
   WHERE [d].[Name] = 'Sales'
ORDER BY [e].EmployeeID

--P04

SELECT  TOP (5) [e].[EmployeeID], [e].[FirstName], [e].[Salary], [d].[Name] AS [DepartmentName]
  FROM [Employees]
	AS [e]
  JOIN [Departments]
	AS [d]
	ON [e].DepartmentID = [d].DepartmentID
   WHERE [e].[Salary] > 15000
ORDER BY [e].[DepartmentID]

--P05
-- We need to get all employees who are not in the [EmployeesProjects] table.
--This way we will find who does not havea project, because if an employee is not in the [EmployeesProjects]
--table and the result is NULL - this means the emp. don't have a project. 
  SELECT 
  TOP (3) [e].[EmployeeID],
          [e].[FirstName]
     FROM [Employees]
       AS [e]
LEFT JOIN [EmployeesProjects]
       AS [ep]
       ON [e].[EmployeeID] = [ep].[EmployeeID]
    WHERE [ep].[ProjectID] IS NULL
 ORDER BY [e].[EmployeeID]


--P06

SELECT [e].[FirstName],[e].[LastName], [e].[HireDate], [d].[Name] AS [DeptName]
  FROM [Employees]
	AS [e]
  JOIN [Departments]
	AS [d]
	ON [e].DepartmentID = [d].DepartmentID
   WHERE [e].[HireDate] > '1.1.1999' AND [d].[Name] IN ('Sales','Finance')
ORDER BY [e].[HireDate]

--P07

SELECT TOP (5) [e].[EmployeeID],[e].[FirstName], [p].[Name] AS [ProjectName]
          FROM [Employees]
		    AS [e]
		  JOIN [EmployeesProjects]
		    AS [ep]
		    ON [e].[EmployeeID] = [ep].[EmployeeID]
		  JOIN [Projects]
		    AS [p]
   		    ON [ep].[ProjectID] = [p].[ProjectID]
	     WHERE [p].[StartDate] > '08-13-2002' AND [p].[EndDate] IS NULL
	  ORDER BY [e].[EmployeeID]
	   

--P08
-- We make a LEFT JOIN on the [Projects] table and try to join with the  dates which are smaller than,
-- 01/01/2005. Because of the LEFT JOIN everything above get's a NULL. If it is higher than 01/01/2005
--Then we would get only 1 record. The LEFT JOIN shows NULL for fields that could not match. the Ineer Join
--Would NOT show the record at all as a complete match is needed. 

   SELECT [e].[EmployeeID],[e].[FirstName], [p].[Name] AS [ProjectName]
     FROM [Employees]
   	   AS [e]
     JOIN [EmployeesProjects]
       AS [ep]
       ON [e].[EmployeeID] = [ep].[EmployeeID]
LEFT JOIN [Projects]
       AS [p]
       ON [ep].[ProjectID] = [p].[ProjectID]
	  AND [p].[StartDate] < '01-01-2005'
    WHERE [e].[EmployeeID] = 24

--09
-- SInce this is a self join with the same table this is the condition [e].[ManagerID] = [m].[EmployeeID]
-- THis means thatfor each employee on the same row we would see his manager. 
SELECT   [e].[EmployeeID], [e].[FirstName],[m].[ManagerID],[m].[FirstName] 
	  AS [ManagerName]
    FROM [Employees]
      AS [e]
    JOIN [Employees]
      AS [m]
  	  ON [e].[ManagerID] = [m].[EmployeeID]
   WHERE [e].[ManagerID] IN (3,7)
ORDER BY [e].[EmployeeID]

select * from Employees

 