using Salvage.Domain.Validations;
using Salvage.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Salvage.Domain.Entities
{
    public class Empresa 
    {
        public Empresa()
        {

        }
        public int? Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public TipoEmpresa TipoEmpresa { get; set; }
        public TipoPessoa TipoPessoa { get; set; } = TipoPessoa.PJ;
        public string Nome { get; set; }
        public string CNPJ_CPF { get; set; }
        public string IE { get; set; } 
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string EnderecoNumero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Email { get; set; } 
        public string Telefone { get; set; }
        public bool Ativo { get; set; } 
        public List<Contato> Contatos { get; set; }
    }
}
