using Salvage.Domain.Entities; 
using System.Collections.Generic;

namespace Salvage.Application.Interfaces
{
    public interface IAppWorkflowPassoService  
    { 
        IEnumerable<WorkflowPasso> ListarTodos();
        IEnumerable<WorkflowPasso> SelecionarPorWorkflow(int id);
        WorkflowPasso SelecionarPorId(int id);
        void Deletar(int id);
        void Incluir(WorkflowPasso entidade);
        void Atualizar(WorkflowPasso entidade);
    }
}
