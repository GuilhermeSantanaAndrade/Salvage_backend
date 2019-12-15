
using Salvage.Domain.ValueObjects;
namespace Salvage.Domain.Entities
{
    public class Seguradora : Empresa
    {
        public Seguradora()
        {
            TipoEmpresa = TipoEmpresa.Seguradora;
        }
    }
}
