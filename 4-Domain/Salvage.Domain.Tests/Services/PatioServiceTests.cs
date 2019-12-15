using Moq;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Services;
using System;
using Xunit;

namespace Salvage.Domain.Tests.Services
{
    public class PatioServiceTests
    {
        [Trait("Categoria", "Testes Patio Service")]
        [Fact(DisplayName = "Incluir Patio - Deve chamar metodo incluir um patio")]
        public void PatioService_IncluirPatio_DeveriaIncluirPatio()
        {
            var patio = new Patio(new ValueObjects.Endereco(), "11951496290");
            var repo = new Mock<IPatioRepository>();

            repo.Setup(r => r.Incluir(patio));
            var service = new PatioService(repo.Object);

            service.Incluir(patio);
            repo.Verify(r => r.Incluir(patio), Times.Once);

        }
        [Trait("Categoria", "Testes Patio Service")]
        [Fact(DisplayName = "Atualizar Patio - Deve chamar metodo atualizar um patio")]
        public void PatioService_AtualizarPatio_DeveriaAtualizarPatio()
        {
            var patio = new Patio(new ValueObjects.Endereco(), "11951496290");
            var repo = new Mock<IPatioRepository>();

            repo.Setup(r => r.Atualizar(patio));
            var service = new PatioService(repo.Object);

            service.Atualizar(patio);
            repo.Verify(r => r.Atualizar(patio), Times.Once);


        }
        [Trait("Categoria", "Testes Patio Service")]
        [Fact(DisplayName = "Deletar Patio - Deve chamar metodo deletar um patio")]
        public void PatioService_DeletarPatio_DeveriaDeletarPatio()
        {
            var id = Guid.NewGuid();
            var repo = new Mock<IPatioRepository>();

            repo.Setup(r => r.Deletar(id));
            var service = new PatioService(repo.Object);

            service.Deletar(id);
            repo.Verify(r => r.Deletar(id), Times.Once);


        }
    }
}