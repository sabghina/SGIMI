CREATE TABLE [dbo].[Admin]
(
	[Id_Admin] INT NOT NULL PRIMARY KEY, 
    [Id_Intervention] INT NOT NULL, 
    [Id_four] INT NOT NULL ,
    CONSTRAINT fk_four FOREIGN KEY (Id_Four) 
    REFERENCES Fournisseur(Id_Four),
    CONSTRAINT fk_intervention FOREIGN KEY (Id_Intervention) 
    REFERENCES Intervention(Id_Intervention)
)
