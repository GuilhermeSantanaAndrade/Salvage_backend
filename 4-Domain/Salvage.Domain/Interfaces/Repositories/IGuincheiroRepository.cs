using Salvage.Domain.Entities;
using System.Collections.Generic;

namespace Salvage.Domain.Interfaces.Repositories
{
    public interface IGuincheiroRepository : IBaseRepository<Guincheiro>
    {
        IEnumerable<Guincheiro> SelecionarPorProximidade();
    }
}
