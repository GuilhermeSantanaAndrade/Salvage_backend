using AutoMapper;
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
    public class EmpresaRepository<T> : IEmpresaRepository<T> where T : class
    {

        private readonly IConfiguration _config;

        public TipoEmpresa TipoEmpresa { get; private set; }

        public EmpresaRepository(IConfiguration config, TipoEmpresa tipoEmpresa)
        {
            _config = config;
            TipoEmpresa = tipoEmpresa;
        }

        public void Atualizar(T entidade)
        {
            try
            {
                var empresa = entidade as Empresa;

                empresa.DataAtualizacao = DateTime.Now;

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"
                        UPDATE Empresa
                            SET Nome = @Nome,
                            CNPJ_CPF = @CNPJ_CPF, 
                            IE = @IE, 
                            Endereco = @Endereco, 
                            EnderecoNumero = @EnderecoNumero, 
                            Bairro = @Bairro, 
                            Complemento = @Complemento, 
                            TipoPessoa = @TipoPessoa, 
                            Cidade = @Cidade, 
                            UF = @UF, 
                            CEP = @CEP, 
                            Telefone = @Telefone, 
                            Email = @Email, 
                            Ativo = @Ativo, 
                            DataAtualizacao = @DataAtualizacao, 
                            Latitude = @Latitude, 
                            Longitude = @Longitude
                        WHERE Guid = @Guid
                        ",
                       empresa, commandType: CommandType.Text);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Deletar(Guid guid)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                conexao.Execute($"DELETE FROM Empresa where Guid = @guid", new { guid }, commandType: CommandType.Text);
            }
        }

        public void Incluir(T entidade)
        {
            try
            {
                var empresa = entidade as Empresa;

                empresa.DataCriacao = DateTime.Now;
                empresa.DataAtualizacao = DateTime.Now;

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"INSERT INTO Empresa  
                                ( Guid, Nome ,CNPJ_CPF, IE, Endereco, EnderecoNumero, Bairro, Complemento, Cidade, UF, CEP, Telefone, Email, 
                                Ativo, DataCriacao, DataAtualizacao, IdTipoEmpresa, Latitude, Longitude, IdUsuarioUltimaAtualizacao  
                                )
                               VALUES 
                                (
                                     @Guid, @Nome, @CNPJ_CPF, @IE, @Endereco, @EnderecoNumero, @Bairro, @Complemento, @Cidade, @UF, @CEP, @Telefone, @Email
                                    ,@Ativo, @DataCriacao, @DataAtualizacao, @TipoEmpresa, @Latitude, @Longitude, NULL
                                ) ",
                       empresa, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<T> ListarTodos()
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                return conexao.Query<T>($"SELECT * FROM Empresa WHERE IdTipoEmpresa = @TipoEmpresa", new { TipoEmpresa }, commandType: CommandType.Text);
            }
        }

        public IEnumerable<T> SelecionarPorCidade(string cidade)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                return conexao.Query<T>($"SELECT * FROM Empresa WHERE Cidade LIKE '%' + '@cidade' + '%' AND IdTipoEmpresa = @TipoEmpresa", new { cidade, TipoEmpresa }, commandType: CommandType.Text);
            }
        }

        public T SelecionarPorCNPJ(string cnpj)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                return conexao.Query<T>($"SELECT * FROM Empresa WHERE CNPJ_CPF = @CNPJ_CPF", new { @CNPJ_CPF = cnpj }, commandType: CommandType.Text).FirstOrDefault();
            }
        }

        public T SelecionarPorId(Guid guid)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            { 
                return conexao.Query<T>($"SELECT * FROM Empresa WHERE Guid = @guid", new { guid }, commandType: CommandType.Text).FirstOrDefault();
            }
        }
        public T SelecionarPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                return conexao.Query<T>($"SELECT * FROM Empresa WHERE Id = @id", new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
        }
    }
}
