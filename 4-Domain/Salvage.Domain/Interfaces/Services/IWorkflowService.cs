
using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Salvage.Domain.Interfaces.Services
{
    public interface IWorkflowService
    {
        IEnumerable<Workflow> ListarTodos();
        IEnumerable<Workflow> SelecionarPorEmpresa(int id);
        Workflow SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(Workflow entidade);
        void Atualizar(Workflow entidade);
    }
}
