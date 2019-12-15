using Microsoft.Extensions.Configuration; 
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.ValueObjects; 
using System;
using System.Collections.Generic; 

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class GuincheiroRepository : EmpresaRepository<Guincheiro>, IGuincheiroRepository
    { 
        private readonly IConfiguration _config; 
        public GuincheiroRepository(IConfiguration config) 
            :base(config, TipoEmpresa.Guincheiro)
        {
            _config = config; 
        } 

        public IEnumerable<Guincheiro> SelecionarPorProximidade()
        {
            throw new NotImplementedException();
        } 
    }
}
