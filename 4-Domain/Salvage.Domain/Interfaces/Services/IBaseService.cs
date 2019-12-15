using System;
using System.Collections.Generic; 

namespace Salvage.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
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
