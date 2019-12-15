
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;

namespace Salvage.Infra.Data.Repositories.SQL
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly IConfiguration _config;

        public ContatoRepository(IConfiguration config)
        {
            _config = config;
        }
        public void Atualizar(Contato entidade)
        {
            try
            {

                entidade.DataAtualizacao = DateTime.Now;

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"
                        UPDATE EmpresaContato
                            SET Nome = @Nome,
                            Celular = @Celular, 
                            Email = @Email, 
                            DataCriacao = @DataCriacao, 
                            DataAtualizacao = @DataAtualizacao
                        WHERE Guid = @Guid
                        ",
                       new { entidade }, commandType: CommandType.Text);
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
                conexao.Execute($"DELETE FROM EmpresaContato where Guid = @id", new { id }, commandType: CommandType.Text);
            }
        }

        public void Incluir(Contato entidade, Empresa empresa)
        {
            try
            {

                entidade.DataCriacao = DateTime.Now;
                entidade.DataAtualizacao = DateTime.Now;

                var dto = new
                {
                    Nome = entidade.Nome,
                    Celular = entidade.Celular,
                    Email = entidade.Email,
                    DataCriacao = entidade.DataCriacao,
                    DataAtualizacao = entidade.DataAtualizacao,
                    IdEmpresa = empresa.Id
                };

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"INSERT INTO EmpresaContato  
                            ( Nome, Celular, Email, DataCriacao, DataAtualizacao )
                            VALUES 
                            ( @Nome, @Celular, @Email, @DataCriacao, @DataAtualizacao ) ",
                       new { dto }, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Contato> ListarTodos()
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                return conexao.Query<Contato>($"SELECT * FROM EmpresaContato", commandType: CommandType.Text);
            }
        }

        public Contato SelecionarPorId(Guid id)
        {

            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                return conexao.Query<Contato>($"SELECT * FROM EmpresaContato WHERE Guid = @id", new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
        }
    }
}
