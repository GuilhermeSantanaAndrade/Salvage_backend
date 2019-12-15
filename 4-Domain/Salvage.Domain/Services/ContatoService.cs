using System;
using System.Collections.Generic;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
namespace Salvage.Domain.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _repositorio;
        public ContatoService(IContatoRepository repositorio)
        {
            _repositorio = repositorio; 
        }

        public void Atualizar(Contato entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public void Deletar(Guid id)
        {
            _repositorio.Deletar(id);
        }

        public void Incluir(Contato entidade, Empresa empresa)
        { 
            _repositorio.Incluir(entidade, empresa);
        }

        public IEnumerable<Contato> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public Contato SelecionarPorId(Guid id)
        {
            return _repositorio.SelecionarPorId(id);
        }
    }
}
