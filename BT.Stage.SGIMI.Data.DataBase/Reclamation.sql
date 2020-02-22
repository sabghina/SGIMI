CREATE TABLE [dbo].[Reclamation]
(
	[Id_Reclamation] INT NOT NULL PRIMARY KEY, 
    [Id_User] INT NOT NULL, 
    [Id_Materiel] INT NOT NULL, 
    [Id_Intervention] INT NOT NULL,
    CONSTRAINT fk3_materiel FOREIGN KEY (Id_Materiel) 
    REFERENCES Materiel(Id_Materiel)
)
