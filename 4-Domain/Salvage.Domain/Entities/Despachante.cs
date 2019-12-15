using System;
using Salvage.Domain.ValueObjects;

namespace Salvage.Domain.Entities
{
    public class Despachante : Empresa
    {
        public Despachante()
        {
            TipoEmpresa = TipoEmpresa.Despachante;
        }
    }
}
