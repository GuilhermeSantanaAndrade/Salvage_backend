using Salvage.Domain.Recursos;
using Salvage.Domain.Validations;
using Salvage.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Entities
{
    public class Patio : Empresa
    {
        public Patio()
        {
            TipoEmpresa = TipoEmpresa.Patio;
        }
        public Patio(Endereco endereco, string celular)
        {
            Validacao.NovoValidador()
                .Quando(endereco == null, MensagemValidacao.EnderecoInvalido)
                .Quando(string.IsNullOrEmpty(celular), MensagemValidacao.CelularInvalido)
                .Quando(string.IsNullOrEmpty(celular) || celular.Length < 10 || celular.Length > 11
                    , MensagemValidacao.CelularInvalido)
                .DispararExcessaoSeExistirErro();

            Endereco = endereco.NomeLogradouro;
            Telefone = celular.Trim();
            TipoEmpresa = TipoEmpresa.Patio;
        }
    }
}
