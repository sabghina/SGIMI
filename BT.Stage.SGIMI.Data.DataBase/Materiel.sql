CREATE TABLE [dbo].[Materiel]
(
	[Id_Materiel] INT NOT NULL PRIMARY KEY, 
    [Ref_Materiel] NCHAR(10) NOT NULL, 
    [Nom_Materiel] NCHAR(10) NOT NULL, 
    [Marque_Materiel] NCHAR(10) NOT NULL
)
