using Dapper;
using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class WorkflowPassoRepository : IWorkflowPassoRepository
    {
        private readonly IConfiguration _config;
        public WorkflowPassoRepository(IConfiguration config) 
        {
            _config = config;
        }

        public void Atualizar(WorkflowPasso entidade)
        {
            try
            {
                var dto = this.EntidadeToDynamic(entidade);


                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"
                        UPDATE WorkflowPasso
                            SET       
                               [Descricao] = @Descricao
                              ,[DescricaoParaFazer] = @DescricaoParaFazer
                              ,[Ordem] = @Ordem
                              ,[EnviaEmail] = @EnviaEmail
                              ,[EnviaSMS] = @EnviaSMS
                              ,[IdWorkflow] = @IdWorkflow
                              ,[TipoEmpresaResponsavel] = @TipoEmpresaResponsavel
                        WHERE Id = @Id
                        ",
                       new
                       {
                           dto.Id,
                           dto.Descricao,
                           dto.DescricaoParaFazer,
                           dto.Ordem,
                           dto.EnviaEmail,
                           dto.EnviaSMS,
                           dto.TipoEmpresaResponsavel,
                           dto.IdWorkflow

                       }, commandType: CommandType.Text);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                conexao.Execute($"DELETE FROM WorkflowPasso where Id = @id", new { id }, commandType: CommandType.Text);
            }
        }

        public void Incluir(WorkflowPasso entidade)
        {
            try
            {
                var dto = this.EntidadeToDynamic(entidade);

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"INSERT INTO WorkflowPasso  
                                ( 
                                  [Descricao]
                                  ,[Ordem]
                                  ,[EnviaEmail]
                                  ,[EnviaSMS]
                                  ,[TipoEmpresaResponsavel]
                                  ,[IdWorkflow]
                                  ,[DescricaoParaFazer]
                                )
                               VALUES 
                                (
                                  @Descricao 
                                  ,@Ordem
                                  ,@EnviaEmail
                                  ,@EnviaSMS
                                  ,@TipoEmpresaResponsavel
                                  ,@IdWorkflow 
                                  ,@DescricaoParaFazer
                                ) ",
                       new
                       {
                           dto.Descricao,
                           dto.Ordem,
                           dto.EnviaEmail,
                           dto.EnviaSMS,
                           dto.TipoEmpresaResponsavel,
                           dto.IdWorkflow

                       }, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<WorkflowPasso> ListarTodos()
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado =  conexao.Query<dynamic>($"SELECT * FROM WorkflowPasso", commandType: CommandType.Text);
                return this.DynamicToListaEntidade(resultado);
            }
        }
          
        public WorkflowPasso SelecionarPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM WorkflowPasso WHERE Id = @id", new { id }, commandType: CommandType.Text).FirstOrDefault();
                return this.DynamicToEntidade(resultado);
            }
        }
        public WorkflowPasso SelecionarProximoPasso(int proximoNaOrdem, int idWorkflow)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM WorkflowPasso WHERE IdWorkflow = @idWorkflow AND Ordem = @proximoNaOrdem", new { idWorkflow, proximoNaOrdem }, commandType: CommandType.Text).FirstOrDefault();
                return this.DynamicToEntidade(resultado);
            }
        }

        public IEnumerable<WorkflowPasso> SelecionarPorWorkflow(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM WorkflowPasso WHERE IdWorkflow = @id", new { id }, commandType: CommandType.Text);
                return this.DynamicToListaEntidade(resultado);
            }
        }
        private dynamic EntidadeToDynamic(WorkflowPasso entidade)
        {
            return new
            {
                entidade.Id,
                entidade.Descricao,
                entidade.DescricaoParaFazer, 
                entidade.Ordem,
                entidade.EnviaEmail,
                entidade.EnviaSMS,
                entidade.TipoEmpresaResponsavel,
                IdWorkflow = entidade.Workflow.Id
            };
        }
        private WorkflowPasso DynamicToEntidade (dynamic dto)
        {
            if (dto == null) return null;
            return new WorkflowPasso
            {
                Id = dto.Id,
                Descricao = dto.Descricao,
                DescricaoParaFazer = dto.DescricaoParaFazer,
                Ordem = dto.Ordem,
                EnviaEmail = dto.EnviaEmail,
                EnviaSMS = dto.EnviaSMS,
                TipoEmpresaResponsavel = (TipoEmpresa) dto.TipoEmpresaResponsavel,
                Workflow = new Workflow { Id = dto.IdWorkflow }
            };
        }

        private List<WorkflowPasso> DynamicToListaEntidade(dynamic dto)
        {
            if (dto == null) return null;

            var lista = new List<WorkflowPasso>();
            foreach (var item in dto)
            {
                lista.Add(this.DynamicToEntidade(item));
            }
            return lista; 
        }
    }
}
