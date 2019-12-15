using System;
using Salvage.Domain.ValueObjects;
namespace Salvage.Domain.Entities
{
    public class Oficina : Empresa
    { 
        public Oficina()
        {
            TipoEmpresa = TipoEmpresa.Oficina;
        }
    }
}
