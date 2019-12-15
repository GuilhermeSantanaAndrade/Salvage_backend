using System;
using System.Collections.Generic;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Domain.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _repositorio;
        public WorkflowService(IWorkflowRepository repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Atualizar(Workflow entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public void Deletar(Guid id)
        {
            _repositorio.Deletar(id);
        }

        public void Incluir(Workflow entidade)
        {
            _repositorio.Incluir(entidade);
        }

        public IEnumerable<Workflow> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public IEnumerable<Workflow> SelecionarPorEmpresa(int id)
        {
            return _repositorio.SelecionarPorEmpresa(id);
        }

        public Workflow SelecionarPorId(Guid id)
        {
            return _repositorio.SelecionarPorId(id);
        }
    }
}
