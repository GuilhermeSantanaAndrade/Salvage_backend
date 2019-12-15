using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories; 

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class SeguradoraRepository : EmpresaRepository<Seguradora>, ISeguradoraRepository
    {
        private readonly IConfiguration _config;
        public SeguradoraRepository(IConfiguration config)
            : base(config, Domain.ValueObjects.TipoEmpresa.Seguradora)
        {
            _config = config;
        }
    }
}
