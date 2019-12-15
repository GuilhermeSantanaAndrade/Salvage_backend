
using Salvage.Application.ViewModels;
using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Salvage.Application.Interfaces
{
    public interface IAppSalvadoService
    {
        IEnumerable<Salvado> ListarTodos();
        Salvado SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(Salvado entidade);
        void Atualizar(Salvado entidade);
        void AtualizarPasso(Guid guidSalvado, PassoViewModel passoVM);
        Salvado SelecionarPorPlaca(string placa);
        IEnumerable<SalvadoHistorico> ListarHistorico(Guid guidSalvado); 
    }
}
