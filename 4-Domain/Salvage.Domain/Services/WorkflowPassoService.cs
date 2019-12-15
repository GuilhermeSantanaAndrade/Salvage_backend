using System;
using System.Collections.Generic;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Domain.Services
{
    public class WorkflowPassoService : IWorkflowPassoService
    {
        private readonly IWorkflowPassoRepository _repositorio;
        public WorkflowPassoService(IWorkflowPassoRepository repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Atualizar(WorkflowPasso entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public void Deletar(int id)
        {
            _repositorio.Deletar(id);
        }

        public void Incluir(WorkflowPasso entidade)
        {
            _repositorio.Incluir(entidade);
        }

        public IEnumerable<WorkflowPasso> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public WorkflowPasso SelecionarPorId(int id)
        {
            return _repositorio.SelecionarPorId(id);
        }

        public IEnumerable<WorkflowPasso> SelecionarPorWorkflow(int id)
        {
            return _repositorio.SelecionarPorWorkflow(id);
        }

        public WorkflowPasso SelecionarProximoPasso(int proximoNaOrdem, int idWorkflow)
        {
            return _repositorio.SelecionarProximoPasso(proximoNaOrdem, idWorkflow);
        }
    }
}
