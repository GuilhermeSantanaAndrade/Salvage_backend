
using Salvage.Domain.Entities;
using System.Collections.Generic;

namespace Salvage.Domain.Interfaces.Services
{
    public interface IWorkflowPassoService
    {
        IEnumerable<WorkflowPasso> ListarTodos();
        IEnumerable<WorkflowPasso> SelecionarPorWorkflow(int id);
        WorkflowPasso SelecionarPorId(int id);
        void Deletar(int id);
        void Incluir(WorkflowPasso entidade);
        void Atualizar(WorkflowPasso entidade);
        WorkflowPasso SelecionarProximoPasso(int proximoNaOrdem, int idWorkflow);
    }
}
