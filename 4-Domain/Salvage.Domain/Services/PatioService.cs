using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Services
{
    public class PatioService : BaseService<Patio>, IPatioService
    {
        private readonly IPatioRepository _repositorio;
        public PatioService(IPatioRepository repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
