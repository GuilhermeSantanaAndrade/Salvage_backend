using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Application.Interfaces
{
    public interface IAppContatoService
    {
        IEnumerable<Contato> ListarTodos();
        Contato SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(Contato entidade, Guid empresa);
        void Atualizar(Contato entidade);
    }
}
