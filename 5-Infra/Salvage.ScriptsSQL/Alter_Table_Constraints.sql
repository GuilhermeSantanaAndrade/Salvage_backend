GO
ALTER TABLE dbo.Usuario 
	ADD CONSTRAINT FK_Usuario_Empresa FOREIGN KEY (IdEmpresa)
	REFERENCES Empresa (Id) 

GO
ALTER TABLE dbo.Empresa 
	ADD CONSTRAINT FK_Empresa_TipoEmpresa FOREIGN KEY (IdTipoEmpresa)
	REFERENCES TipoEmpresa (Id);

GO

ALTER TABLE dbo.Empresa 
	ADD CONSTRAINT FK_Empresa_Usuario FOREIGN KEY (IdUsuarioUltimaAtualizacao)
	REFERENCES Usuario (Id);
GO 

ALTER TABLE dbo.Workflow 
	ADD CONSTRAINT FK_Workflow_Empresa FOREIGN KEY (IdEmpresa)
	REFERENCES Empresa (Id);
GO

ALTER TABLE dbo.Workflow 
	ADD CONSTRAINT FK_Workflow_Usuario FOREIGN KEY (IdUsuario)
	REFERENCES Usuario (Id);
GO

ALTER TABLE dbo.WorkflowPasso
	ADD CONSTRAINT FK_WorkflowPasso_Workflow FOREIGN KEY (IdWorkflow)
	REFERENCES Workflow (Id);
GO


ALTER TABLE dbo.SalvadoHistorico
	ADD CONSTRAINT FK_SalvadoHistorico_Salvado FOREIGN KEY (IdSalvado)
	REFERENCES Salvado (Id);
GO

ALTER TABLE dbo.SalvadoHistorico
	ADD CONSTRAINT FK_SalvadoHistorico_Usuario FOREIGN KEY (IdUsuario)
	REFERENCES Usuario (Id);
GO

ALTER TABLE dbo.SalvadoFotos
	ADD CONSTRAINT FK_SalvadoFotos_Salvado FOREIGN KEY (IdSalvado)
	REFERENCES Salvado (Id);
GO

ALTER TABLE dbo.SalvadoFotos
	ADD CONSTRAINT FK_SalvadoFotos_Usuario FOREIGN KEY (IdUsuario)
	REFERENCES Usuario (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_EmpresaDespachante FOREIGN KEY (IdDespachante)
	REFERENCES Empresa (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_EmpresaGuincheiro FOREIGN KEY (IdGuincheiro)
	REFERENCES Empresa (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_EmpresaPatio FOREIGN KEY (IdPatio)
	REFERENCES Empresa (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_EmpresaOficina FOREIGN KEY (IdOficina)
	REFERENCES Empresa (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_EmpresaSeguradora FOREIGN KEY (IdSeguradora)
	REFERENCES Empresa (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_Workflow FOREIGN KEY (IdWorkflow)
	REFERENCES Workflow (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_WorkflowPasso FOREIGN KEY (IdWorkflowPassoAtual)
	REFERENCES WorkflowPasso (Id);
GO

ALTER TABLE dbo.Salvado
	ADD CONSTRAINT FK_Salvado_UsuarioUltimaAtualizacao FOREIGN KEY (IdUsuarioUltimaAtualizacao)
	REFERENCES Usuario (Id);
GO

ALTER TABLE dbo.AlertaUsuario
	ADD CONSTRAINT FK_AlertaUsuario_Alerta FOREIGN KEY (IdAlerta)
	REFERENCES Alerta (Id);
GO

ALTER TABLE dbo.AlertaUsuario
	ADD CONSTRAINT FK_AlertaUsuario_Usuario FOREIGN KEY (IdUsuario)
	REFERENCES Usuario (Id);
GO


ALTER TABLE dbo.EmpresaContato
	ADD CONSTRAINT FK_Empresa_EmpresaContato FOREIGN KEY (IdEmpresa)
	REFERENCES Empresa (Id);
GO



