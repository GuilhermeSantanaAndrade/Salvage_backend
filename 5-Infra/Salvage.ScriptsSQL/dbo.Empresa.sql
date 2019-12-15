
CREATE TABLE [dbo].[Empresa]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Guid] UNIQUEIDENTIFIER NOT NULL , 
    [Nome] VARCHAR(200) NOT NULL, 
    [CNPJ_CPF] VARCHAR(20) NOT NULL, 
    [IE] VARCHAR(20) NULL, 
    [Endereco] VARCHAR(80) NOT NULL, 
    [Cidade] VARCHAR(40) NOT NULL, 
    [UF] CHAR(2) NOT NULL, 
    [CEP] CHAR(8) NOT NULL, 
    [Telefone] VARCHAR(12) NULL, 
    [Email] VARCHAR(40) NOT NULL, 
    [Ativo] BIT NOT NULL , 
    [Latitude] FLOAT NULL , 
    [Longitude] FLOAT NULL , 
    [DataCriacao] DATETIME NOT NULL , 
    [DataAtualizacao] DATETIME NOT NULL, 
    [IdUsuarioUltimaAtualizacao] INT NULL,
	[IdTipoEmpresa] INT NULL
)
GO