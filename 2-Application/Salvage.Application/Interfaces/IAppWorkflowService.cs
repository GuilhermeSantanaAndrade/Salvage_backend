using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Salvage.Application.Interfaces
{
    public interface IAppWorkflowService
    {
        IEnumerable<Workflow> ListarTodos();
        Workflow SelecionarPassos(Guid id);
        IEnumerable<Workflow> SelecionarPorEmpresa(Guid id);
        Workflow SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(Workflow entidade);
        void Atualizar(Workflow entidade); 
    }
}
