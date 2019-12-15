using Salvage.Domain.Entities;
using Salvage.Domain.Recursos;
using Salvage.Domain.Validations;
using Salvage.Domain.ValueObjects;
using System;
using Xunit;

namespace Salvage.Domain.Tests.Entities
{
    public class GuincheiroTests
    {

        private Guincheiro NovoGuincheiro()
        {
            var nome = "Guincheiro da Silva";
            var endereco = new Endereco
            {
                Logradouro = "Avenida",
                NomeLogradouro = "Paulista, 902",
                Bairro = "Consolação",
                CEP = "03322-232",
                Cidade = "São Paulo",
                Estado = new Estado { Id = 1, UF = "SP" }
            };
            var email = new Email("thiago@teste.com.br");
            var celular = "11944566598";
            var ativo = true;
            return new Guincheiro(nome, DateTime.Now, endereco, email, celular, ativo);
        }

        //AAA
        [Trait("Categoria", "Testes Guincheiro")]
        [Fact(DisplayName = "Criação Guincheiros - Deve Criar uma instancia de guincheiro")]
        public void Guincheiro_CriarGuincheiro_DeveCriarGuincheiroValido()
        { 
            // Act
            var guincheiro = NovoGuincheiro(); 
                       
            // Assert
            Assert.NotNull(guincheiro); 
        }


        [Trait("Categoria", "Testes Guincheiro")]
        [Theory(DisplayName = "Criação Guincheiros - Deveria jogar ExcecaoDeDominio para guincheiro sem nome")]
        [InlineData("")]
        [InlineData(null)]
        public void Guincheiro_CriarGuincheiro_DeveriaThrowExcecaoDeDominioCriarGuincheiroSemNome(string nomeInvalido)
        {

            string nome = nomeInvalido;
            var dataCadastro = DateTime.Now;
            var endereco = new Endereco
            {
                NomeLogradouro = "Tietê",
                Logradouro = "Marginal, 2020",
                CEP = "45645-030",
                Bairro = "Bairro Teste",
                Cidade = "São Paulo",
                Estado = new Estado { Id = 1, UF = "SP" }
            };
            var email = new Email("guincheiro@teste.com");
            var celular = "11943433094";
            var ativo = true;

            ExcecaoDeDominio ex = Assert.Throws<ExcecaoDeDominio>(() => new Guincheiro(nome, dataCadastro, endereco, email, celular, ativo));


            Assert.Equal(MensagemValidacao.NomeFantasiaInvalido, ex.Mensagens.Find(p => p.Contains(MensagemValidacao.NomeFantasiaInvalido)));
        }

        [Trait("Categoria", "Testes Guincheiro")]
        [Theory(DisplayName = "Criação Guincheiros - Deveria mostrar mensagem de erro para guincheiro celular invalido")]
        [InlineData("")]
        [InlineData(null)] public void Guincheiro_CriarGuincheiro_DeveriaMostrarMensagemErroAoCriarGuincheiroSemCelular(string celularInvalido)
        {

            string nome = "GUincheiro da Silvva";
            var dataCadastro = DateTime.Now;
            var endereco = new Endereco
            {
                NomeLogradouro = "Tietê",
                Logradouro = "Marginal, 2020",
                CEP = "45645-030",
                Bairro = "Bairro Teste",
                Cidade = "São Paulo",
                Estado = new Estado { Id = 1, UF = "SP" }
            };
            var email = new Email("guincheiro@teste.com");
            string celular = celularInvalido;
            var ativo = true;


            ExcecaoDeDominio ex = Assert.Throws<ExcecaoDeDominio>(() => new Guincheiro(nome, dataCadastro, endereco, email, celular, ativo));


            Assert.Equal(MensagemValidacao.CelularInvalido, ex.Mensagens.Find(p => p.Contains(MensagemValidacao.CelularInvalido)));
        } 
    }
}
