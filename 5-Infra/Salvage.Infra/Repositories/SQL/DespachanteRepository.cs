using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.ValueObjects;
using Salvage.Domain.Interfaces.Repositories;

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class DespachanteRepository : EmpresaRepository<Despachante>, IDespachanteRepository
    {
        private readonly IConfiguration _config;
        public DespachanteRepository(IConfiguration config) 
            :base(config, TipoEmpresa.Despachante)
        {
            _config = config;
        } 
    }
}
