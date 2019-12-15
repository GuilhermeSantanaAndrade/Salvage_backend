using System;
using System.Collections.Generic;
using Salvage.Application.Interfaces;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Application
{
    public class AppBaseService<T> : IAppBaseService<T> where T : class
    {
        private readonly IBaseService<T> _service; 
        public AppBaseService(IBaseService<T> service)
        {
            _service = service;
        }

        public void Atualizar(T entidade)
        {
            _service.Atualizar(entidade);
        }

        public void Deletar(Guid id)
        {
            _service.Deletar(id);
        }

        public void Incluir(T entidade)
        {
            _service.Incluir(entidade);
        }

        public IEnumerable<T> ListarTodos()
        {
            return _service.ListarTodos();
        }

        public IEnumerable<T> SelecionarPorCidade(string cidade)
        {
            return _service.SelecionarPorCidade(cidade);
        }

        public T SelecionarPorCNPJ(string cnpj)
        {
            return _service.SelecionarPorCNPJ(cnpj);
        }

        public T SelecionarPorId(Guid id)
        {
            return _service.SelecionarPorId(id);
        } 
    }
}
