CREATE TABLE [dbo].[Workflow]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Guid] UNIQUEIDENTIFIER NOT NULL, 
    [Descricao] VARCHAR(20) NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [DataAtualizacao] DATETIME NOT NULL, 
    [IdEmpresa] INT NOT NULL,
    [IdUsuario] INT NOT NULL
);
 