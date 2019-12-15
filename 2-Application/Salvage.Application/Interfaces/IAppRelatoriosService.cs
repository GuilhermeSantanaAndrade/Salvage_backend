using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Application.Interfaces
{
    public interface IAppRelatoriosService
    {
        IEnumerable<Salvado> ListarSalvadosPorData(DateTime dataInicio, DateTime dataFim, Guid guidEmpresa);
        IEnumerable<Salvado> ListarSalvadosPorSeguradora(Guid guidSeguradora);
        IEnumerable<Salvado> ListarSalvadosPorStatus(WorkflowPasso passo, Guid guidEmpresa);

    }
}
