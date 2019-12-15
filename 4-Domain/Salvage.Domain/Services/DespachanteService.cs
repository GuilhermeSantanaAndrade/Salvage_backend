using System;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Domain.Services
{
    public class DespachanteService : BaseService<Despachante>, IDespachanteService
    {
        private readonly IDespachanteRepository _repositorio;
        public DespachanteService(IDespachanteRepository repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
