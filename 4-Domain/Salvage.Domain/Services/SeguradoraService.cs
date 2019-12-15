using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services; 

namespace Salvage.Domain.Services
{
    public class SeguradoraService : BaseService<Seguradora>, ISeguradoraService
    {
        private readonly ISeguradoraRepository _repositorio;
        public SeguradoraService(ISeguradoraRepository repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        } 
    }
}
