CREATE TABLE [dbo].[Table1]
(
	[User_Id] INT NOT NULL PRIMARY KEY, 
    [User_Name] CHAR(50) NOT NULL,
    [User_Family_Name] CHAR(50) NOT NULL,
    [User_Mail] NCHAR(10) NOT NULL, 
    [User_Password] NCHAR(10) NOT NULL, 
    [User_Phone] NCHAR(20) NOT NULL, 
    [Unity_Management_Id] NCHAR(20) NOT NULL
)
