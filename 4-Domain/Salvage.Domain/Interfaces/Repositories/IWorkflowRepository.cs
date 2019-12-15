using System;
using System.Collections.Generic;
using Salvage.Domain.Entities;

namespace Salvage.Domain.Interfaces.Repositories
{
    public interface IWorkflowRepository
    {
        IEnumerable<Workflow> ListarTodos();
        IEnumerable<Workflow> SelecionarPorEmpresa(int id);
        Workflow SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(Workflow entidade);
        void Atualizar(Workflow entidade);
    }
}
