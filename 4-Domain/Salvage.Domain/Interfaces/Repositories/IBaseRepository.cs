using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    { 
        IEnumerable<T> ListarTodos();
        T SelecionarPorId(Guid id); 
        void Deletar(Guid id);
        void Incluir(T entidade);
        void Atualizar(T entidade);
        IEnumerable<T> SelecionarPorCidade(string cidade);
        T SelecionarPorCNPJ(string cnpj);
        T SelecionarPorId(int id);
    }
}
