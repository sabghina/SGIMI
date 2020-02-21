CREATE TABLE [dbo].[Fournisseur]
(
	[Id_F] INT NOT NULL PRIMARY KEY, 
    [Nom_F] NCHAR(20) NOT NULL, 
    [Pre_F] CHAR(20) NOT NULL, 
    [Tel_F] INT NOT NULL, 
    [Email_F] CHAR(20) NOT NULL, 
    [Ville_F] CHAR(20) NOT NULL
)
