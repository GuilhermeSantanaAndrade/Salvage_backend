 
 CREATE TABLE [dbo].[Alerta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Codigo] VARCHAR(20) NOT NULL, 
    [Descricao] VARCHAR(100) NOT NULL, 
    [DataEmissao] DATETIME NOT NULL
)
GO
CREATE TABLE [dbo].[AlertaUsuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [DataLido] DATETIME NULL, 
    [IdAlerta] INT NOT NULL, 
    [IdUsuario] INT NOT NULL
)
GO
CREATE TABLE [dbo].[Salvado]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Guid] UNIQUEIDENTIFIER NOT NULL, 
    [Sinistro] VARCHAR(20) NOT NULL, 
    [Placa] VARCHAR(10) NOT NULL, 
    [Modelo] VARCHAR(30) NOT NULL, 
    [Marca] VARCHAR(20) NOT NULL, 
    [Cor] VARCHAR(20) NOT NULL,
    [Ano] INT NOT NULL, 
    [ValorFipe] MONEY NOT NULL, 
    [Apolice] VARCHAR(15) NOT NULL, 
    [NomeSegurado] VARCHAR(50) NOT NULL, 
    [Cidade] VARCHAR(40) NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [DataAtualizacao] DATETIME NOT NULL, 
    [Observacoes] VARCHAR(1000) NULL, 
    [IdDespachante] INT NULL, 
    [IdPatio] INT NULL, 
    [IdGuincheiro] INT NULL, 
    [IdOficina] INT NULL, 
    [IdSeguradora] INT NOT NULL, 
    [IdUsuarioUltimaAtualizacao] INT NOT NULL, 
    [IdWorkflow] INT NOT NULL, 
    [IdWorkflowPassoAtual] INT NOT NULL
)
GO
CREATE TABLE [dbo].[SalvadoHistorico]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [DescricaoEvento] VARCHAR(100) NOT NULL, 
    [DataEvento] DATETIME NOT NULL, 
    [IdSalvado] INT NOT NULL, 
    [IdUsuario] INT NOT NULL
)
GO
CREATE TABLE [dbo].[TipoEmpresa]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descricao] VARCHAR(20) NOT NULL
)
GO
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
GO
CREATE TABLE [dbo].[WorkflowPasso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descricao] VARCHAR(30) NOT NULL, 
    [Ordem] INT NOT NULL, 
    [EnviaEmail] BIT NOT NULL, 
    [EnviaSMS] BIT NOT NULL, 
    [IdWorkflow] INT NOT NULL 
)
GO
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
CREATE TABLE [dbo].[SalvadoFotos]
(
	[Guid] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [DataCriacao] DATETIME NOT NULL, 
    [Descricao] VARCHAR(20) NULL, 
    [Url] VARCHAR(200) NOT NULL,  
    [IdSalvado] INT NOT NULL,
    [IdUsuario] INT NOT NULL
)
GO
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

CREATE TABLE [dbo].[EmpresaContato]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Guid] UNIQUEIDENTIFIER NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Celular] VARCHAR(12) NULL, 
    [Email] VARCHAR(40) NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [DataAtualizacao] DATETIME NOT NULL,
    [IdEmpresa] INT NOT NULL
)