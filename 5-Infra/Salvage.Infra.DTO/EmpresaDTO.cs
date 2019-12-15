using Salvage.Domain.ValueObjects;
using System; 
namespace Salvage.Infra.DTO
{
    public class EmpresaDTO
    {
        public EmpresaDTO()
        {

        }
        public int?  Id { get; set; } 
        public Guid Guid { get; set; }
        public string Nome { get; set; }
        public string CNPJ_CPF { get; set; }
        public string IE { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool Ativo { get; set; }
        public int? IdUsuarioUltimaAtualizacao { get; set; }
        public int IdTipoEmpresa { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
    }
}
