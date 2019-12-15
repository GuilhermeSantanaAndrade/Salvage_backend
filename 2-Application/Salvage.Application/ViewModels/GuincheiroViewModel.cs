using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvage.Application.ViewModels
{
    public class GuincheiroViewModel
    { 
        public Guid Guid { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Logradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; } 
        public string UF { get; set; }
        public int? UFId { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }
        public bool Ativo { get; set; }
    }
}
