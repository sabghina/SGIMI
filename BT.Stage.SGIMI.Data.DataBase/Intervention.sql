CREATE TABLE [dbo].[Intervention]
(
	[Id_Intervention] INT NOT NULL PRIMARY KEY, 
    [Type_Intervention] NCHAR(10) NOT NULL, 
    [Id_Materiel] INT NOT NULL, 
    [Id_Admin] INT NOT NULL, 
    [Id_ST] INT NOT NULL,
    CONSTRAINT fk2_admin FOREIGN KEY (Id_Admin) 
    REFERENCES Admin(Id_Admin),
    CONSTRAINT fk2_materiel FOREIGN KEY (Id_Materiel) 
    REFERENCES Materiel(Id_Materiel),
    CONSTRAINT fk_st FOREIGN KEY (Id_ST) 
    REFERENCES SocieteTierce(Id_ST)
)
