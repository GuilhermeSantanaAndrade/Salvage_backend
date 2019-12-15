using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Application.ViewModels
{
    public class EmailViewModel
    { 
        public string Destinatario { get; set; }
        public string BodyHTML { get; set; }
        public string Assunto { get; set; }
    }
}
