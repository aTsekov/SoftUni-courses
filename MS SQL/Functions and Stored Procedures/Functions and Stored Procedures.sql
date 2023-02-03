USE [SoftUni]
GO

--P01

CREATE OR ALTER PROC [usp_GetEmployeesSalaryAbove35000]
-- Creat or Alter is usefull as if the procedure exists it will just change it.
-- However it is not syntax accepted in Judge
	   AS
	BEGIN 
			SELECT [FirstName], [LastName]
              FROM [Employees]
             WHERE [Salary] > 35000

	  END
EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

--P02