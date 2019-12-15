using System;
using System.Collections.Generic;
using System.Linq;
using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Application
{
    public class AppWorkflowService : IAppWorkflowService
    {
        private readonly IWorkflowService _service;
        private readonly IWorkflowPassoService _passoService;
        private readonly ISeguradoraService _empresaService;
        public AppWorkflowService(IWorkflowService service
            , IWorkflowPassoService passoService 
            , ISeguradoraService empresaService) 
        {
            _service = service;
            _empresaService = empresaService;
            _passoService = passoService;
        }

        public void Atualizar(Workflow entidade)
        {
            _service.Atualizar(entidade);
        }

        public void Deletar(Guid id)
        {
            _service.Deletar(id);
        }

        public void Incluir(Workflow entidade)
        {
            entidade.EmpresaPertencente = _empresaService
                .SelecionarPorId(entidade.EmpresaPertencente.Guid);

            _service.Incluir(entidade);
        }

        public IEnumerable<Workflow> ListarTodos()
        {
            return _service.ListarTodos();
        }

        public Workflow SelecionarPassos(Guid id)
        {
            var workflow = _service.SelecionarPorId(id);
            workflow.Passos = _passoService.SelecionarPorWorkflow( (int) workflow.Id).ToList();
            return workflow;
        }

        public IEnumerable<Workflow> SelecionarPorEmpresa(Guid guid)
        {
            var empresa = _empresaService.SelecionarPorId(guid); 
            return _service.SelecionarPorEmpresa((int) empresa.Id);
        }

        public Workflow SelecionarPorId(Guid id)
        {
            return _service.SelecionarPorId(id);
        }
    }
}
