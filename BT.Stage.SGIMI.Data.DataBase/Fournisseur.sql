CREATE TABLE [dbo].[Fournisseur]
(
	[Id_Four] INT NOT NULL PRIMARY KEY, 
    [Nom_F] NCHAR(10) NOT NULL, 
    [Id_Admin] INT NOT NULL, 
    [Id_Materiel] INT NOT NULL
    CONSTRAINT fk_admin FOREIGN KEY (Id_Admin) 
    REFERENCES Admin(Id_Admin),
    CONSTRAINT fk_materiel FOREIGN KEY (Id_Materiel) 
    REFERENCES Materiel(Id_Materiel)
)
