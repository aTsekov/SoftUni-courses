CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY , -- NOT NULL BY DEFAULT,
UserName VARCHAR (30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
Picture VARBINARY (MAX),
LastLogin DATETIME2 ,
IsDeleted BIT
);

INSERT INTO Users
VALUES	
	('Pesho','Pass1234', NULL, '10-15-2022',0),
	('Pesho1','Pass1234', NULL, '10-16-2022',1),
	('Pesho2','Pass1234', NULL, '10-17-2022',0),
	('Pesho3','Pass1234', NULL, '10-18-2022',1),
	('Pesho4','Pass1234', NULL, '10-19-2022',0)


	ALTER TABLE Users DROP CONSTRAINT PK__Users__3214EC07589D293E; -- remove the PK of the table. Take the key from the folder
	-- Keys from the Object Explorer

	ALTER TABLE Users ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, UserName) -- After we've deleted the PK_Id
	--I've created a new PK whic his a combination of the fields Id and UserName

	ALTER TABLE Users ADD CONSTRAINT CHK_PasswordMinLen CHECK (LEN([Password]) >=5); -- Add check if a field has min 5 chars.

	ALTER TABLE [Users] ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLogin -- change the default value of a field

	ALTER TABLE Users DROP CONSTRAINT PK_IDUsername --Drop the PK of ID and UserName
	ALTER TABLE Users ADD CONSTRAINT PK_Id PRIMARY KEY (Id) --Make only the Id to be PK

	ALTER TABLE Users ADD CONSTRAINT UC_UserName UNIQUE (UserName) -- Make sure the values in User Name are unique
	SELECT * FROM Users 