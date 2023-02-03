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

CREATE OR ALTER PROC [usp_GetEmployeesSalaryAboveNumber] @minSalary DECIMAL(18,4)
		 AS 
	  BEGIN
				SELECT [FirstName],
                           [LastName]
                      FROM [Employees]
                     WHERE [Salary] >= @minSalary
	    END

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100

--P03
CREATE PROC [usp_GetTownsStartingWith](@searchedString NVARCHAR(50))

		AS

		BEGIN

			   DECLARE @stringCount int = LEN(@searchedString)

				SELECT [Name] FROM Towns

				 WHERE LEFT([Name],@stringCount) = @searchedString

		END
 

 EXEC  [usp_GetTownsStartingWith] 'b'
 SELECT *FROM Towns
