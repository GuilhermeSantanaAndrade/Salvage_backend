using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repositorio; 

        public BaseService(IBaseRepository<T> repositorio) 
        {
            _repositorio = repositorio;
        }
        public void Deletar(Guid id)
        {
            _repositorio.Deletar(id); 
        } 

        public T SelecionarPorId(Guid id)
        {
            return _repositorio.SelecionarPorId(id);
        }

        public IEnumerable<T> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public void Incluir(T entidade)
        {
            _repositorio.Incluir(entidade);
        }

        public void Atualizar(T entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public IEnumerable<T> SelecionarPorCidade(string cidade)
        {
            return _repositorio.SelecionarPorCidade(cidade);
        }

        public T SelecionarPorCNPJ(string cnpj)
        {
            return _repositorio.SelecionarPorCNPJ(cnpj);
        }

        public T SelecionarPorId(int id)
        {
            return _repositorio.SelecionarPorId(id);
        }
    }
}
