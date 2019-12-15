using System;
using System.Collections.Generic; 

namespace Salvage.Domain.Entities
{
    public class Workflow
    {
        public int? Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public List<WorkflowPasso> Passos { get; set; } = new List<WorkflowPasso>();
        public Empresa EmpresaPertencente { get; set; } = new Empresa();
        public Usuario Usuario { get; set; } = new Usuario();
    }
}
