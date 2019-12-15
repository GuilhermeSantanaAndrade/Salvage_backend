using Salvage.Domain.Recursos;
using Salvage.Domain.Validations;
using Salvage.Domain.ValueObjects;
using System;
using System.Linq;

namespace Salvage.Domain.Entities
{
    public class Guincheiro : Empresa 
    {
        public Guincheiro()
        {
            TipoEmpresa = TipoEmpresa.Guincheiro;
        }
        public Guincheiro(string nome, DateTime dataCadastro, Endereco endereco, Email email, string celular, bool ativo)
        {
            Validacao.NovoValidador()
                .Quando(string.IsNullOrEmpty(nome), MensagemValidacao.NomeFantasiaInvalido)
                .Quando(string.IsNullOrEmpty(celular), MensagemValidacao.CelularInvalido) 
                .DispararExcessaoSeExistirErro();

            Nome = nome.Trim();
            TipoEmpresa = TipoEmpresa.Guincheiro;
            DataCriacao = dataCadastro; 
            Endereco = endereco.NomeLogradouro;
            Telefone = celular.Trim();
            Email = email.Endereco; 
            Ativo = ativo; 
        } 
    }
}
