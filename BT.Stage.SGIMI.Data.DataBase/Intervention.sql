CREATE TABLE [dbo].[Intervention]
(
	[Id_Intervention] INT NOT NULL PRIMARY KEY, 
    [Type_Intervention] CHAR(30) NOT NULL, 
    [Admin_Id] INT NOT NULL, 
    [Id_Soc_T] INT NOT NULL, 
    [Id_Rec] NCHAR(10) NOT NULL
)
