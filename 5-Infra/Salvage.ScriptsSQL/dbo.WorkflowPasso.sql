CREATE TABLE [dbo].[WorkflowPasso]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descricao] VARCHAR(30) NOT NULL, 
    [Ordem] INT NOT NULL, 
    [EnviaEmail] BIT NOT NULL, 
    [EnviaSMS] BIT NOT NULL, 
    [IdWorkflow] INT NOT NULL 
)
