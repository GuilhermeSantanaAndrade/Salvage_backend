using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salvage.Application
{
    public class AppRelatoriosService : IAppRelatoriosService
    {
        private readonly IAppSalvadoService _salvado;
        private readonly IAppWorkflowPassoService _passo;
        private readonly IAppSeguradoraService _seguradora;

        public AppRelatoriosService(IAppSalvadoService salvado, IAppSeguradoraService seguradora, IAppWorkflowPassoService passo)
        {
            _salvado = salvado;
            _seguradora = seguradora;
            _passo = passo;
        }

        public IEnumerable<Salvado> ListarSalvadosPorData(DateTime dataInicio, DateTime dataFim, Guid guidEmpresa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Salvado> ListarSalvadosPorSeguradora(Guid guidSeguradora)
        {
            var seguradora = _seguradora.SelecionarPorId(guidSeguradora); 
            var salvados = _salvado.ListarTodos().Where(salvado => salvado.Seguradora.Id == seguradora.Id);
            var salvadoPassos = new List<Salvado>();
            foreach (var item in salvados)
            {
                item.PassoEtapa = _passo.SelecionarPorId((int)item.PassoEtapa.Id);
                salvadoPassos.Add(item);
            }
            return salvadoPassos;
        }

        public IEnumerable<Salvado> ListarSalvadosPorStatus(WorkflowPasso passo, Guid guidEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
