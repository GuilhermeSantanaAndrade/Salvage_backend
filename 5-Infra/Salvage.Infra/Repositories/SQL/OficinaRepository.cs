using Salvage.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class OficinaRepository : EmpresaRepository<Oficina>, IOficinaRepository
    {
        private readonly IConfiguration _config;
        public OficinaRepository(IConfiguration config)
            : base(config, TipoEmpresa.Oficina)
        {
            _config = config;
        } 
    }
}
