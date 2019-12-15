using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Interfaces.Services
{
    public interface IContatoService
    {
        IEnumerable<Contato> ListarTodos();
        Contato SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(Contato entidade, Empresa empresa);
        void Atualizar(Contato entidade);
    }
}
