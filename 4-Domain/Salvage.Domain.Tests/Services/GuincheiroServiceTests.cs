using Moq;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
using Salvage.Domain.Services;
using Salvage.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Salvage.Domain.Tests.Services
{
    public class GuincheiroServiceTests
    {
        private Guincheiro NovoGuincheiro()
        {
            var nome = "Guincheiro da Silva";
            var endereco = new Endereco {
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

        [Trait("Categoria", "Testes GuincheiroService")]
        [Fact(DisplayName = "Incluir Guincheiros - Deve retornar um Id de sucesso")]
        public void GuincheiroService_IncluirGuincheiro_DeveRetornarIdDeSucesso()
        {
            var guid = Guid.NewGuid();
            var guincheiro = NovoGuincheiro();
            guincheiro.Guid = guid;
            var repo = new Mock<IGuincheiroRepository>();
            repo.Setup(r => r.Incluir(guincheiro));

            var service = new GuincheiroService(repo.Object);
            service.Incluir(guincheiro);


            repo.Verify(r => r.Incluir(guincheiro), Times.Once); 
        }

        [Trait("Categoria", "Testes GuincheiroService")]
        [Fact(DisplayName = "Deletar Guincheiro - Deve executar a função deletar uma vez")] 
        public void GuincheiroService_DeletarGuincheiro_DeveExecutarFuncaoDeletarUmaVez()
        {
            var id = Guid.NewGuid();
            var repo = new Mock<IGuincheiroRepository>();
            repo.Setup(r => r.Deletar(id));

            var service = new GuincheiroService(repo.Object);
            service.Deletar(id);


            repo.Verify(r => r.Deletar(id), Times.Once);
        }

        [Trait("Categoria", "Testes GuincheiroService")]
        [Fact(DisplayName = "Listar Guincheiros - Deve retornar uma lista de guincheiros")]
        public void GuincheiroService_ListarGuincheiro_DeveRetornarUmaListaDeGuincheiros()
        {
            var teste = new List<Guincheiro>();
            teste.Add(NovoGuincheiro());
            teste.Add(NovoGuincheiro());
            teste.Add(NovoGuincheiro());
            teste.Add(NovoGuincheiro());
            teste.Add(NovoGuincheiro());
            teste.Add(NovoGuincheiro());

            var repo = new Mock<IGuincheiroRepository>();
            repo.Setup(r => r.ListarTodos()).Returns(teste);

            var service = new GuincheiroService(repo.Object);
            var lista = (List<Guincheiro>)service.ListarTodos();

            repo.Verify(r => r.ListarTodos(), Times.Once);
            Assert.True(teste.Count == lista.Count);
        }

        [Trait("Categoria", "Testes GuincheiroService")]
        [Fact(DisplayName = "Atualizar Guincheiros - Deve executar metodo de atualizar")] 
        public void GuincheiroService_AtualizarGuincheiro_DeveExecutarMetodoAtualizar()
        {
            var repositorio = new Mock<IGuincheiroRepository>();
            var guincheiroTeste = NovoGuincheiro();

            var service = new GuincheiroService(repositorio.Object); 
            repositorio.Setup(r => r.Atualizar(guincheiroTeste));

            service.Atualizar(guincheiroTeste);
            repositorio.Verify(r => r.Atualizar(guincheiroTeste), Times.Once); 
        }

    }
}
