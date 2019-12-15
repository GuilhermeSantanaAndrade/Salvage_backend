using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Entities
{
    public class Usuario
    {
        public int? Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }
        public Empresa EmpresaPertencente { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
