

using Salvage.Domain.Entities;
using Salvage.Domain.Recursos;
using Salvage.Domain.Validations;
using Xunit;

namespace Salvage.Domain.Tests.Entities
{
    public class PatioTests
    {

        [Trait("Categoria", "Testes Patio")]
        [Fact(DisplayName = "Criação Patio - Deve Criar uma instancia de patio")]
        public void Patio_CriarPatio_DeveCriarUmPatioValido()
        {
            var patio = new Patio(new ValueObjects.Endereco(), "1195149529");

            Assert.NotNull(patio);
        }

        [Trait("Categoria", "Testes Patio")]
        [Theory(DisplayName = "Criação Patio - Deve ter um endereco")]
        [InlineData(null)]
        public void Patio_CriarPatio_DeveTerUmEndereco(ValueObjects.Endereco endereco)
        {
            ExcecaoDeDominio ex = Assert.Throws<ExcecaoDeDominio>(
                () => new Patio(endereco, "1195149529"));

            Assert.Equal(MensagemValidacao.EnderecoInvalido
                , ex.Mensagens.Find(p => p.Contains(MensagemValidacao.EnderecoInvalido)));
        }
        [Trait("Categoria", "Testes Patio")]
        [Theory(DisplayName = "Criação Patio - Deve ter um celular")]
        [InlineData(null)]
        [InlineData("")]
        public void Patio_CriarPatio_DeveTerUmCelular(string celularInvalido)
        { 
            ExcecaoDeDominio ex = Assert.Throws<ExcecaoDeDominio>(
                () => new Patio(new ValueObjects.Endereco(), celularInvalido));

            Assert.Equal(MensagemValidacao.CelularInvalido
                , ex.Mensagens.Find(p => p.Contains(MensagemValidacao.CelularInvalido))); 
        }
    }
}
