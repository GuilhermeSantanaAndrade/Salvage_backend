using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Entities
{
    public class SalvadoHistorico
    {
        public string DescricaoEvento { get; set; }
        public DateTime DataEvento { get; set; } = DateTime.Now;
        public int IdSalvado { get; set; }
        public int IdUsuario { get; set; }
    }
}
