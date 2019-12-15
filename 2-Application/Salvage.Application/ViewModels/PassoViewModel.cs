using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Application.ViewModels
{
    public class PassoViewModel
    {
        public string Observacao { get; set; }
        public int? IdUsuario { get; set; }
        public Guid? GuidUsuario { get; set; } 
        public int IdPasso { get; set; }
    }
}
