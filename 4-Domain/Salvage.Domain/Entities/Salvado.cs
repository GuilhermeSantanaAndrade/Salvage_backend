using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Entities
{
    public class Salvado
    {
        public int? Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public string Sinistro { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public decimal ValorFipe { get; set; }
        public string Apolice { get; set; }
        public string NomeSegurado { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Observacoes { get; set; }
        public bool Excluido { get; set; }
        public Despachante Despachante { get; set; } = new Despachante();
        public Patio Patio { get; set; } = new Patio();
        public Guincheiro Guincheiro { get; set; } = new Guincheiro();
        public Oficina Oficina { get; set; } = new Oficina();
        public Seguradora Seguradora { get; set; } = new Seguradora();
        public Usuario Usuario { get; set; } = new Usuario();
        public Workflow Workflow { get; set; } = new Workflow();
        public WorkflowPasso PassoEtapa { get; set; } = new WorkflowPasso();
    }
} 