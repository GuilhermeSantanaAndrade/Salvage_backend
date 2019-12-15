using Salvage.Domain.Entities;  
using System.Collections.Generic;

namespace Salvage.Application.Interfaces
{
    public interface IAppGuincheiroService: IAppBaseService<Guincheiro>
    {
        IEnumerable<Guincheiro> SelecionarPorProximidade();
    }
}
