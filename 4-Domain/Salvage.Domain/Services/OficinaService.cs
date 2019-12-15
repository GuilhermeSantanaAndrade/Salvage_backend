using System;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Domain.Services
{
    public class OficinaService : BaseService<Oficina>, IOficinaService
    {
        private readonly IOficinaRepository _repositorio;
        public OficinaService(IOficinaRepository repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
