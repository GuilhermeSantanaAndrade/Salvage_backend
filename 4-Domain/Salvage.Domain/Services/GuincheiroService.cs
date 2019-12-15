using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salvage.Domain.Services
{
    public class GuincheiroService : BaseService<Guincheiro>, IGuincheiroService
    {
        private readonly IGuincheiroRepository _repositorio;
        public GuincheiroService(IGuincheiroRepository repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }  
        IEnumerable<Guincheiro> IGuincheiroService.SelecionarPorProximidade()
        {
            return _repositorio.SelecionarPorProximidade();
        }
    }
}
