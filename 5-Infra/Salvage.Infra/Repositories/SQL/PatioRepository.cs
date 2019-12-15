using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.ValueObjects;
using Salvage.Domain.Interfaces.Repositories;

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class PatioRepository : EmpresaRepository<Patio>, IPatioRepository
    {
        private readonly IConfiguration _config; 
        public PatioRepository(IConfiguration config)
            : base(config, TipoEmpresa.Patio)
        {
            _config = config;
        } 
    }
}
