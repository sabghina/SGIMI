CREATE TABLE [dbo].[SocieteTierce]
(
	[Id_ST] INT NOT NULL PRIMARY KEY, 
    [Type_ST] NCHAR(10) NOT NULL, 
    [Id_Intervention] INT NOT NULL,
    CONSTRAINT fk2_intervention FOREIGN KEY (Id_Intervention) 
    REFERENCES Intervention(Id_Intervention)
)
