using System;
using System.Collections.Generic;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
using Salvage.Domain.ValueObjects;

namespace Salvage.Domain.Services
{
    public class SalvadoService : ISalvadoService
    {
        private readonly ISalvadoRepository _repositorio;
        public SalvadoService(ISalvadoRepository repositorio) 
        {
            _repositorio = repositorio;
        }

        public void Atualizar(Salvado entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public void Deletar(Guid id)
        {
            _repositorio.Deletar(id);
        }

        public void Incluir(Salvado entidade)
        {
            _repositorio.Incluir(entidade);
        }

        public void IncluirHistorico(SalvadoHistorico historico)
        {
            _repositorio.IncluirHistorico(historico);
        }

        public IEnumerable<SalvadoHistorico> ListarHistorico(int idSalvado)
        {
            return _repositorio.ListarHistorico(idSalvado);
        }

        public IEnumerable<Salvado> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public int SelecionarIdDependendoTipoEmpresa(TipoEmpresa tipo, Guid guidSalvado)
        {
            return _repositorio.SelecionarIdDependendoTipoEmpresa(tipo, guidSalvado);
        }

        public Salvado SelecionarPorId(Guid id)
        {
            return _repositorio.SelecionarPorId(id);
        }

        public Salvado SelecionarPorPlaca(string placa)
        {
            return _repositorio.SelecionarPorPlaca(placa);
        }
    }
}
