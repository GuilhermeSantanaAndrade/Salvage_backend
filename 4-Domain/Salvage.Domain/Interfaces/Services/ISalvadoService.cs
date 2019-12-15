using Salvage.Domain.Entities;
using Salvage.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Salvage.Domain.Interfaces.Services
{
    public interface ISalvadoService
    {
        IEnumerable<Salvado> ListarTodos();
        Salvado SelecionarPorId(Guid id);
        void Deletar(Guid id);
        void Incluir(Salvado entidade);
        void Atualizar(Salvado entidade);
        Salvado SelecionarPorPlaca(string placa);
        IEnumerable<SalvadoHistorico> ListarHistorico(int idSalvado);
        void IncluirHistorico(SalvadoHistorico historico);
        int SelecionarIdDependendoTipoEmpresa(TipoEmpresa tipo, Guid guidSalvado);
    }
}
