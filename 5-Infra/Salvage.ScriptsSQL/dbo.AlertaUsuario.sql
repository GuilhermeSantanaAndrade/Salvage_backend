CREATE TABLE [dbo].[AlertaUsuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [DataLido] DATETIME NULL, 
    [IdAlerta] INT NOT NULL, 
    [IdUsuario] INT NOT NULL
)
