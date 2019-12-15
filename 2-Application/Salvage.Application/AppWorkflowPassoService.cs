using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salvage.Application
{
    public class AppWorkflowPassoService: IAppWorkflowPassoService
    {
        private readonly IWorkflowPassoService _service; 

        public AppWorkflowPassoService(IWorkflowPassoService service) 
        {
            _service = service; 
        }

        public void Atualizar(WorkflowPasso entidade)
        {
            _service.Atualizar(entidade);
        }

        public void Deletar(int id)
        {
            _service.Deletar(id);
        }

        public void Incluir(WorkflowPasso entidade)
        {
            _service.Incluir(entidade);
        }

        public IEnumerable<WorkflowPasso> ListarTodos()
        {
            return _service.ListarTodos();
        }

        public WorkflowPasso SelecionarPorId(int id)
        {
            return _service.SelecionarPorId(id);
        }

        public IEnumerable<WorkflowPasso> SelecionarPorWorkflow(int id)
        { 
            return _service.SelecionarPorWorkflow(id);
        }
    }
}
