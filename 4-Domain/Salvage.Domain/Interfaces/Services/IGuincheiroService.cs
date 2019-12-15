using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Interfaces.Services
{
    public interface IGuincheiroService : IBaseService<Guincheiro>
    {
        IEnumerable<Guincheiro> SelecionarPorProximidade();
    }
}
