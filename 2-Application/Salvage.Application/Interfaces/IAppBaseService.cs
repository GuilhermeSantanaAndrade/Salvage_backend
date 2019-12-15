using System;
using System.Collections.Generic;

namespace Salvage.Application.Interfaces
{
    public interface IAppBaseService<T> where T : class
    {
        IEnumerable<T> SelecionarPorCidade(string cidade);
        T SelecionarPorCNPJ(string cnpj);
        IEnumerable<T> ListarTodos();
        T SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(T entidade);
        void Atualizar(T entidade);
    }
}
