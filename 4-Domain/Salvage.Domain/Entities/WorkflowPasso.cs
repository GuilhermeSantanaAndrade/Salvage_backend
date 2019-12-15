using Salvage.Domain.ValueObjects;
using System; 

namespace Salvage.Domain.Entities
{
    public class WorkflowPasso
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public string DescricaoParaFazer { get; set; }
        public int Ordem { get; set; }
        public bool EnviaEmail { get; set; }
        public bool EnviaSMS { get; set; }
        public TipoEmpresa TipoEmpresaResponsavel { get; set; } = TipoEmpresa.Seguradora;
        public Workflow Workflow { get; set; } = new Workflow();
    }
}
