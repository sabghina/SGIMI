CREATE TABLE [dbo].[User]
(
	[Id_User] INT NOT NULL PRIMARY KEY, 
    [Nom_User] NCHAR(20) NOT NULL, 
    [Prenom_User] NCHAR(20) NOT NULL, 
    [Tel_User] INT NOT NULL, 
    [Email_User] NCHAR(10) NOT NULL, 
    [Mot_de_passe_User] NCHAR(10) NOT NULL, 
    [Id_Unite_gestion] INT NOT NULL, 
    [Id_Reclamation] INT NOT NULL, 
    [Id_Materiel] INT NOT NULL,
    
    CONSTRAINT fk_unitegestion FOREIGN KEY (Id_Unite_Gestion) 
    REFERENCES Unite_Gestion(Id_Unite_Gestion)
)
