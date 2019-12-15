CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Guid] UNIQUEIDENTIFIER NOT NULL, 
    [Login] VARCHAR(50) NOT NULL, 
    [Senha] VARCHAR(20) NOT NULL, 
    [Administrador] BIT NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [DataAtualizacao] DATETIME NOT NULL,
    [IdEmpresa] INT NOT NULL
)
