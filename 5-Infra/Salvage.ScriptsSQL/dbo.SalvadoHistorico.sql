CREATE TABLE [dbo].[SalvadoHistorico]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [DescricaoEvento] VARCHAR(100) NOT NULL, 
    [DataEvento] DATETIME NOT NULL, 
    [IdSalvado] INT NOT NULL, 
    [IdUsuario] INT NOT NULL
)
