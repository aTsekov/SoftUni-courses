USE[Gringotts]
GO

--P01

SELECT COUNT(*)
	AS [Count]
  FROM [WizzardDeposits]

-- P02

SELECT MAX([MagicWandSize])
    AS [LongestMagicWand]
  FROM [WizzardDeposits]

--P03

    SELECT [DepositGroup], MAX([MagicWandSize])
	    AS [[LongestMagicWand]
      FROM [WizzardDeposits]
  GROUP BY [DepositGroup]

--P04

SELECT TOP (2) [DepositGroup]	    
		  FROM [WizzardDeposits]
	  GROUP BY [DepositGroup]
  ORDER BY AVG([MagicWandSize])

--P05

   SELECT [DepositGroup], SUM([DepositAmount])
       AS [TotalSum]
     FROM [WizzardDeposits]
 GROUP BY [DepositGroup]

--P06
  
   SELECT [DepositGroup], SUM([DepositAmount])
       AS [TotalSum]
     FROM [WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
 GROUP BY [DepositGroup]


 --P07
  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

--P08

  SELECT [DepositGroup], [MagicWandCreator] 
      AS [MagicWandCreator], MIN([DepositCharge]) 
	  AS [MinDepositCharge] 
    FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

-- P09

  SELECT [AgeGroup],
         COUNT(*)
      AS [WizardCount]
    FROM (
              SELECT 
                     CASE
                          WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
                          WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
                          WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
                          WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
                          WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
                          WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
                          ELSE '[61+]'
                      END
                  AS [AgeGroup]
                FROM [WizzardDeposits]
         )
      AS [AgeGroupSubquery]
GROUP BY [AgeGroup]

--P10

SELECT DISTINCT LOWER(LEFT([FirstName], 1)) 
      AS [FirstLetter]
    FROM [WizzardDeposits]
   WHERE [DepositGroup] = 'Troll Chest'
GROUP BY LOWER(LEFT([FirstName], 1))
      
ORDER BY [FirstLetter] ASC;

--P11

SELECT [DepositGroup],
         [IsDepositExpired],
         AVG([DepositInterest])
      AS [AverageInterest]
    FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC,
         [IsDepositExpired]

-- P12

SELECT SUM([Difference])
    AS [SumDifference]
  FROM (
                SELECT [FirstName]
                    AS [Host Wizard],
                       [DepositAmount]     
                    AS [Host Wizard Deposit],
                       LEAD([FirstName]) OVER(ORDER BY [Id])
                    AS [Guest Wizard],
                       LEAD([DepositAmount]) OVER(ORDER BY [Id])
                    AS [Guest Wizard Deposit],
                       [DepositAmount] - LEAD([DepositAmount]) OVER(ORDER BY [Id])
                    AS [Difference]
                  FROM [WizzardDeposits]
       ) AS [DifferenceSubQuery]
	------------------

	USE [SoftUni]
	GO

--P13

SELECT [DepartmentId], SUM([Salary])
	AS [TotalSalary]
  FROM [Employees]
GROUP BY [DepartmentID]

--P14

  SELECT [DepartmentId], MIN([Salary])
	  AS [MinimumSalary]
    FROM [Employees]
   WHERE [DepartmentID] IN (2,5,7) AND [HireDate] > 01/01/2000
GROUP BY [DepartmentID]
 

 -- P15

 SELECT * -- Copy certain records from one table to a newly created one based on criteria. 
  INTO [EmployeesWithSalaryOver30000]       
  FROM [Employees]
 WHERE [Salary] > 30000

 DELETE
   FROM [EmployeesWithSalaryOver30000]
  WHERE [ManagerID] = 42


 SELECT [DepartmentID],
         AVG([Salary])
      AS [AverageSalary]
    FROM [EmployeesWithSalaryOver30000]
GROUP BY [DepartmentID]

--P16
SELECT [DepartmentId], MAX([Salary])
	  AS [MaxSalary]
    FROM [Employees]   
GROUP BY [DepartmentID]
 HAVING  MAX([Salary]) NOT BETWEEN 30000 AND 70000

 --P17

 SELECT COUNT(*)
     AS [Count]
   FROM [Employees]
  WHERE [ManagerID] IS NULL
 
 --P18

 -- Problem 18
SELECT 
DISTINCT [DepartmentID],
         [Salary]
      AS [ThirdHighestSalary]
    FROM (
              SELECT [DepartmentID],
                     [Salary],
                     DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC)
                  AS [SalaryRank]
                FROM [Employees]
         )
      AS [SalaryRankingSuquery]
   WHERE [SalaryRank] = 3
 
-- Problem 19
  SELECT 
TOP (10) [e].[FirstName],
         [e].[LastName],
         [e].[DepartmentID]
    FROM [Employees]
      AS [e]
   WHERE [e].[Salary] > (
                              SELECT AVG([Salary])
                                  AS [AverageSalary]
                                FROM [Employees]
                                  AS [eSub]
                               WHERE [eSub].[DepartmentID] = [e].[DepartmentID]
                            GROUP BY [DepartmentID]
                         )
ORDER BY [e].[DepartmentID]
