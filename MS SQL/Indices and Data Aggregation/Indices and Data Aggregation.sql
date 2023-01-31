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



 SELECT * FROM [WizzardDeposits]

 
