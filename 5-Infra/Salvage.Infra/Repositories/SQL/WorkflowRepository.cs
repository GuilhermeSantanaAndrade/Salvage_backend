using Dapper;
using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly IConfiguration _config;
        public WorkflowRepository(IConfiguration config) 
        {
            _config = config;
        }

        public void Atualizar(Workflow entidade)
        {
            try
            {
                entidade.DataAtualizacao = DateTime.Now;

                var dto = this.EntidadeToDynamic(entidade);


                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"
                        UPDATE Workflow
                            SET       
                               [Descricao] = @Descricao
                              ,[DataAtualizacao] = @DataAtualizacao
                              ,[IdEmpresa] = @IdEmpresa
                              ,[IdUsuario] = @IdUsuario
                        WHERE Guid = @Guid
                        ",
                       new
                       {
                           dto.Guid, 
                           dto.DataAtualizacao,
                           dto.Descricao,
                           dto.IdEmpresa,
                           dto.IdUsuario
                       }, commandType: CommandType.Text);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Deletar(Guid id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                conexao.Execute($"DELETE FROM Workflow where Guid = @id", new { id }, commandType: CommandType.Text);
            }
        }

        public void Incluir(Workflow entidade)
        {
            try
            {
                entidade.DataCriacao = DateTime.Now;
                entidade.DataAtualizacao = DateTime.Now;

                var dto = this.EntidadeToDynamic(entidade);

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"INSERT INTO Workflow  
                                ( 
                                  [Guid] 
                                  ,[DataCriacao]
                                  ,[DataAtualizacao]
                                  ,[Descricao]
                                  ,[IdEmpresa]
                                  ,[IdUsuario] 
                                )
                               VALUES 
                                (
                                  @Guid 
                                  ,@DataCriacao
                                  ,@DataAtualizacao
                                  ,@Descricao
                                  ,@IdEmpresa
                                  ,@IdUsuario 
                                ) ",
                       new
                       {
                           dto.Guid,
                           dto.DataCriacao,
                           dto.DataAtualizacao,
                           dto.Descricao,
                           dto.IdEmpresa,
                           dto.IdUsuario
                       }, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Workflow> ListarTodos()
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM Workflow", commandType: CommandType.Text);
                return this.DynamicToListaEntidade(resultado);
            }
        }

        public IEnumerable<Workflow> SelecionarPorEmpresa(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM Workflow WHERE IdEmpresa = @id", new { id }, commandType: CommandType.Text);
                return this.DynamicToListaEntidade(resultado);
            }
        }

        public Workflow SelecionarPorId(Guid id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM Workflow WHERE Guid = @id", new { id }, commandType: CommandType.Text).FirstOrDefault();
                return this.DynamicToEntidade(resultado);
            }
        }
        private dynamic EntidadeToDynamic(Workflow entidade)
        {
            return new
            {
                entidade.Guid,
                entidade.DataCriacao,
                entidade.DataAtualizacao,
                entidade.Descricao,
                IdEmpresa = entidade.EmpresaPertencente.Id,
                IdUsuario = entidade.Usuario.Id
            };
        }
        private Workflow DynamicToEntidade(dynamic dto)
        {
            if (dto == null) return null;
            return new Workflow
            {
                Id = dto.Id,
                Guid = dto.Guid,
                DataCriacao = dto.DataCriacao,
                DataAtualizacao = dto.DataAtualizacao, 
                EmpresaPertencente = new Empresa { Id = dto.IdEmpresa },
                Usuario = new Usuario { Id = dto.IdUsuario },
                Descricao = dto.Descricao
            };
        }

        private List<Workflow> DynamicToListaEntidade(dynamic dto)
        {
            if (dto == null) return null;

            var lista = new List<Workflow>();
            foreach (var item in dto)
            {
                lista.Add(this.DynamicToEntidade(item));
            }
            return lista;
        }
    }
}
