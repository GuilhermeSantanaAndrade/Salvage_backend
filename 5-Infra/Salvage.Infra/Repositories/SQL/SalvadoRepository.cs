using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.ValueObjects;

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class SalvadoRepository : ISalvadoRepository
    {
        private readonly IConfiguration _config;
        public SalvadoRepository(IConfiguration config) 
        {
            _config = config;
        }

        public void Atualizar(Salvado entidade)
        {
            try
            {

                entidade.DataAtualizacao = DateTime.Now;
                var dto = this.EntidadeToDynamic(entidade);

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"
                        UPDATE Salvado
                            SET       
                             [Sinistro] = ISNULL(@Sinistro, Sinistro)
                            ,[Placa] = ISNULL(@Placa, Placa)
                            ,[Modelo] = ISNULL(@Modelo, Modelo)
                            ,[Marca] = ISNULL(@Marca, Marca)
                            ,[Cor] = ISNULL(@Cor, Cor)
                            ,[Ano] = ISNULL(@Ano, Ano)
                            ,[ValorFipe] = ISNULL(@ValorFipe, ValorFipe)
                            ,[Apolice] = ISNULL(@Apolice, Apolice)
                            ,[NomeSegurado] = ISNULL(@NomeSegurado, NomeSegurado)
                            ,[Cidade] = ISNULL(@Cidade , Cidade)
                            ,[DataAtualizacao] = @DataAtualizacao
                            ,[Observacoes] = ISNULL(@Observacoes, Observacoes)
                            ,[IdDespachante] = ISNULL(CONVERT(INT,@IdDespachante), IdDespachante)
                            ,[IdPatio] = ISNULL(CONVERT(INT,@IdPatio), IdPatio)
                            ,[IdGuincheiro] = ISNULL(CONVERT(INT,@IdGuincheiro), IdGuincheiro)
                            ,[IdOficina] = ISNULL(CONVERT(INT,@IdOficina ), IdOficina)
                            ,[IdUsuarioUltimaAtualizacao] = ISNULL(CONVERT(INT,@IdUsuarioUltimaAtualizacao), IdUsuarioUltimaAtualizacao)
                            ,[IdWorkflow] = ISNULL(CONVERT(INT,@IdWorkflow), IdWorkflow)
                            ,[IdWorkflowPassoAtual] = ISNULL(CONVERT(INT,@IdWorkflowPassoAtual), IdWorkflowPassoAtual)
                        WHERE Guid = @Guid
                        ",
                       new
                       { 
                           dto.Guid,
                           dto.Sinistro,
                           dto.Placa,
                           dto.Modelo,
                           dto.Marca,
                           dto.Cor,
                           dto.Ano,
                           dto.ValorFipe,
                           dto.Apolice,
                           dto.NomeSegurado,
                           dto.Cidade, 
                           dto.DataAtualizacao,
                           dto.Observacoes,
                           dto.IdDespachante,
                           dto.IdPatio,
                           dto.IdGuincheiro,
                           dto.IdOficina,
                           dto.IdSeguradora,
                           dto.IdUsuarioUltimaAtualizacao,
                           dto.IdWorkflow,
                           dto.IdWorkflowPassoAtual
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
                conexao.Execute($"UPDATE Salvado SET Excluido = 1 where Guid = @id", new { id }, commandType: CommandType.Text);
            }
        }

        public void Incluir(Salvado entidade)
        {
            try
            {
                entidade.DataCriacao = DateTime.Now;
                entidade.DataAtualizacao = DateTime.Now;
                var dto = this.EntidadeToDynamic(entidade); 

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"INSERT INTO Salvado  
                                ( 
                                  [Guid]
                                  ,[Sinistro]
                                  ,[Placa]
                                  ,[Modelo]
                                  ,[Marca]
                                  ,[Cor]
                                  ,[Ano]
                                  ,[ValorFipe]
                                  ,[Apolice]
                                  ,[NomeSegurado]
                                  ,[Cidade]
                                  ,[DataCriacao]
                                  ,[DataAtualizacao]
                                  ,[Observacoes] 
                                  ,[IdSeguradora]
                                  ,[IdUsuarioUltimaAtualizacao]
                                  ,[IdWorkflow]
                                  ,[IdWorkflowPassoAtual] 
                                )
                               VALUES 
                                (
                                  @Guid
                                  ,@Sinistro
                                  ,@Placa
                                  ,@Modelo
                                  ,@Marca
                                  ,@Cor
                                  ,@Ano
                                  ,@ValorFipe
                                  ,@Apolice
                                  ,@NomeSegurado
                                  ,@Cidade
                                  ,@DataCriacao
                                  ,@DataAtualizacao
                                  ,@Observacoes 
                                  ,@IdSeguradora
                                  ,@IdUsuarioUltimaAtualizacao
                                  ,@IdWorkflow
                                  ,@IdWorkflowPassoAtual
                                ) ",
                       new
                       {
                           dto.Guid,
                           dto.Sinistro,
                           dto.Placa,
                           dto.Modelo,
                           dto.Marca,
                           dto.Cor,
                           dto.Ano,
                           dto.ValorFipe,
                           dto.Apolice,
                           dto.NomeSegurado,
                           dto.Cidade,
                           dto.DataCriacao,
                           dto.DataAtualizacao,
                           dto.Observacoes,
                           dto.IdDespachante,
                           dto.IdPatio,
                           dto.IdGuincheiro,
                           dto.IdOficina,
                           dto.IdSeguradora,
                           dto.IdUsuarioUltimaAtualizacao,
                           dto.IdWorkflow,
                           dto.IdWorkflowPassoAtual
                       }, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Salvado> ListarTodos()
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM Salvado", commandType: CommandType.Text);
                var lista = this.DynamicToListaEntidades(resultado);
                return lista;
            }
        } 

        public Salvado SelecionarPorPlaca(string placa)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM Salvado WHERE Placa = @placa ", new { placa }, commandType: CommandType.Text).FirstOrDefault();
                return this.DynamicToEntidade(resultado);
            }
        }
        public int SelecionarIdDependendoTipoEmpresa(TipoEmpresa tipo, Guid guidSalvado)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var idEmpresa = SelecionarTipoIdPorTipoEmpresa(tipo);
                var id = conexao.Query<int>($"SELECT {idEmpresa} FROM Salvado WHERE Guid = @guidSalvado ", new { guidSalvado }, commandType: CommandType.Text).FirstOrDefault();
                return id;
            }
        }
        public Salvado SelecionarPorId(Guid id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var resultado = conexao.Query<dynamic>($"SELECT * FROM Salvado WHERE Guid = @id", new { id }, commandType: CommandType.Text).FirstOrDefault();
                return this.DynamicToEntidade(resultado);
            }
        }


        #region " HISTORICO SALVADO "


        public IEnumerable<SalvadoHistorico> ListarHistorico(int idSalvado)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                return conexao.Query<SalvadoHistorico>($"SELECT * FROM SalvadoHistorico WHERE IdSalvado = @idSalvado ", new { idSalvado }, commandType: CommandType.Text);
            }
        }
        public void IncluirHistorico(SalvadoHistorico historico)
        { 
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                conexao.Query(
                    @"INSERT INTO [SalvadoHistorico]  
                               ([DescricaoEvento]
                               ,[DataEvento]
                               ,[IdSalvado]
                               ,[IdUsuario])
                               VALUES
                               (@DescricaoEvento 
                               ,@DataEvento 
                               ,@IdSalvado 
                               ,@IdUsuario )",
                   historico, commandType: CommandType.Text);
            }
        }
        #endregion



        #region " PRIVATES "

        private string SelecionarTipoIdPorTipoEmpresa(TipoEmpresa tipo)
        {
            string tipoId = string.Empty;
            switch (tipo)
            {
                case TipoEmpresa.Seguradora:
                    tipoId = "IdSeguradora";
                    break;
                case TipoEmpresa.Guincheiro:
                    tipoId = "IdGuincheiro";
                    break;
                case TipoEmpresa.Despachante:
                    tipoId = "IdDespachante";
                    break;
                case TipoEmpresa.Patio:
                    tipoId = "IdPatio";
                    break;
                case TipoEmpresa.Oficina:
                    tipoId = "IdOficina";
                    break;
            }
            return tipoId;
        }


        private List<Salvado> DynamicToListaEntidades(dynamic dto)
        {
            if (dto == null) return null;

            var lista = new List<Salvado>();
            foreach (var item in dto)
            {
                lista.Add(this.DynamicToEntidade(item));
            }
            return lista;
        }

        private Salvado DynamicToEntidade(dynamic dto)
        {
            if (dto == null) return null;

            var salvado = new Salvado
            {
                Id = dto.Id,
                Guid = dto.Guid,
                DataCriacao = dto.DataCriacao,
                DataAtualizacao = dto.DataAtualizacao,
                Sinistro = dto.Sinistro,
                Placa = dto.Placa,
                Modelo = dto.Modelo,
                Marca = dto.Marca,
                Cor = dto.Cor,
                Ano = dto.Ano,
                ValorFipe = dto.ValorFipe,
                Apolice = dto.Apolice,
                NomeSegurado = dto.NomeSegurado,
                Cidade = dto.Cidade,
                Observacoes = dto.Observacoes,
                Excluido = dto.Excluido,
                Despachante = new Despachante { Id = dto.IdDespachante },
                Patio = new Patio { Id = dto.IdPatio },
                Guincheiro = new Guincheiro { Id = dto.IdGuincheiro },
                Oficina = new Oficina { Id = dto.IdOficina },
                Seguradora = new Seguradora { Id = dto.IdSeguradora },
                Usuario = new Usuario { Id = dto.IdUsuarioUltimaAtualizacao },
                Workflow = new Workflow { Id = dto.IdWorkflow },
                PassoEtapa = new WorkflowPasso { Id = dto.IdWorkflowPassoAtual }

            };
            return salvado;
        }
        private dynamic EntidadeToDynamic(Salvado entidade)
        {
            return new
            {
                entidade.Guid,
                entidade.Sinistro,
                entidade.Placa,
                entidade.Modelo,
                entidade.Marca,
                entidade.Cor,
                entidade.Ano,
                entidade.ValorFipe,
                entidade.Apolice,
                entidade.NomeSegurado,
                entidade.Cidade,
                entidade.DataCriacao,
                entidade.DataAtualizacao,
                entidade.Observacoes,
                IdDespachante = (int?)entidade.Despachante.Id,
                IdPatio = (int?)entidade.Patio.Id,
                IdGuincheiro = (int?)entidade.Guincheiro.Id,
                IdOficina = (int?)entidade.Oficina.Id,
                IdSeguradora = (int?)entidade.Seguradora.Id,
                IdUsuarioUltimaAtualizacao = (int?)entidade.Usuario.Id,
                IdWorkflow = (int?)entidade.Workflow.Id,
                IdWorkflowPassoAtual = (int?)entidade.PassoEtapa.Id
            };
        }
        #endregion 
    }
}
