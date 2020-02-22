CREATE TABLE [dbo].[Materiel]
(
	[Id_Materiel] INT NOT NULL PRIMARY KEY, 
    [Nom_Materiel] NCHAR(10) NOT NULL, 
    [Reference_Materiel] NCHAR(10) NOT NULL, 
    [Id_Four] INT NOT NULL, 
    [Id_User] INT NOT NULL, 
    [Id_Reclamation] INT NOT NULL,
    CONSTRAINT fk2_four FOREIGN KEY (Id_Four) 
    REFERENCES Fournisseur(Id_Four),
    CONSTRAINT fk_reclamation FOREIGN KEY (Id_Reclamation) 
    REFERENCES Reclamation(Id_Reclamation),
    
)
