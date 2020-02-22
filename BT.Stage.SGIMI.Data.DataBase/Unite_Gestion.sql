CREATE TABLE [dbo].[Unite_Gestion]
(
	[Id_Unite_Gestion] INT NOT NULL PRIMARY KEY, 
    [Nbre_User] INT NOT NULL, 
    [Id_Admin] INT NOT NULL,
    CONSTRAINT fk3_admin FOREIGN KEY (Id_Admin) 
    REFERENCES Admin(Id_Admin)
)
