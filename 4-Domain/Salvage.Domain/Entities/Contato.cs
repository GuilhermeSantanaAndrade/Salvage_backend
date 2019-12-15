using Salvage.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Entities
{
    public class Contato
    {
        public Contato()
        {

        }
        public Guid Guid { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
