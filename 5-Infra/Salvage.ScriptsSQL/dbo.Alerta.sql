CREATE TABLE [dbo].[Alerta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Codigo] VARCHAR(20) NOT NULL, 
    [Descricao] VARCHAR(100) NOT NULL, 
    [DataEmissao] DATETIME NOT NULL
)
