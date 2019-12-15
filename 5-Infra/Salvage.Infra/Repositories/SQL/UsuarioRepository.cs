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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _config;

        public UsuarioRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Atualizar(Usuario usuario)
        {
            try
            { 
                usuario.DataAtualizacao = DateTime.Now;
                var dto = this.EntidadeToDynamic(usuario);

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Query(
                        @"
                        UPDATE Usuario
                        SET  
                          Login = @login
                          Senha = @senha
                          Administrador =  @administrador
                          DataAtualizacao = @dataatualizacao
                          IdEmpresa = @idempresa 
                        WHERE Guid = @guid
                        ",
                       new
                       {
                           dto.login,
                           dto.guid,
                           dto.senha,
                           dto.administrador, 
                           dto.dataatualizacao,
                           dto.idempresa
                       }, commandType: CommandType.Text);
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
                conexao.Execute($"DELETE FROM Usuario where Guid = @guid", new { guid }, commandType: CommandType.Text);
            }
        }

        public void Incluir(Usuario usuario)
        {
            try
            {
                usuario.DataCriacao = DateTime.Now;
                usuario.DataAtualizacao = DateTime.Now;

                var dto = this.EntidadeToDynamic(usuario);

                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
                {
                    conexao.Execute(
                        @"INSERT INTO Usuario  
                                ( 
                                    Login, 
                                    Guid, 
                                    Senha, 
                                    Administrador, 
                                    DataCriacao, 
                                    DataAtualizacao, 
                                    IdEmpresa
                                )
                               VALUES 
                                ( 
                                    @login, 
                                    @guid, 
                                    @senha, 
                                    @administrador, 
                                    @datacriacao, 
                                    @dataatualizacao, 
                                    @idempresa 
                                ) ",
                       new {
                           dto.login,
                           dto.guid,
                           dto.senha,
                           dto.administrador,
                           dto.datacriacao,
                           dto.dataatualizacao,
                           dto.idempresa }, 
                       commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Usuario> SelecionarPorEmpresa(int idEmpresa)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var retorno = conexao
                    .Query<dynamic>(@"SELECT * FROM Usuario WHERE IdEmpresa = @idEmpresa", new { idEmpresa }, commandType: CommandType.Text);
                return this.DynamicToListaEntidades(retorno);
            }
        }

        public Usuario SelecionarPorId(Guid guid)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var retorno = conexao
                    .Query<dynamic>(@"SELECT * FROM Usuario WHERE Guid = @guid", new { guid }, commandType: CommandType.Text)
                    .FirstOrDefault();
                return this.DynamicToEntidade(retorno);
            }
        }

        public Usuario SelecionarPorLogin(string login)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var retorno = conexao
                    .Query<dynamic>(@"SELECT * FROM Usuario WHERE Login = @login", new { login }, commandType: CommandType.Text)
                    .FirstOrDefault();
                return this.DynamicToEntidade(retorno);
            }
        }

        public Usuario SelecionarPorLoginSenha(string login, string senha)
        {
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("conexaoSQL")))
            {
                var retorno = conexao
                    .Query<dynamic>(@"SELECT * FROM Usuario WHERE Login = @login AND Senha = @senha", new { login, senha }, commandType: CommandType.Text)
                    .FirstOrDefault();
                return this.DynamicToEntidade(retorno);
            }
        }


        private List<Usuario> DynamicToListaEntidades(dynamic dto)
        {
            if (dto == null) return null;

            var lista = new List<Usuario>();
            foreach (var item in dto)
            {
                lista.Add(this.DynamicToEntidade(item));
            }
            return lista;
        }

        private Usuario DynamicToEntidade(dynamic dto)
        {
            if (dto == null) return null;
            return new Usuario
            {
                Id = dto.Id,
                Guid = dto.Guid,
                Login = dto.Login,
                Administrador = dto.Administrador,
                DataCriacao = dto.DataCriacao,
                DataAtualizacao = dto.DataAtualizacao,
                EmpresaPertencente = new Empresa { Id = dto.IdEmpresa }
            };
        }
        private dynamic EntidadeToDynamic(Usuario usuario)
        {
            return new
            {
                guid = usuario.Guid,
                login = usuario.Login,
                senha = usuario.Senha,
                administrador = usuario.Administrador,
                datacriacao = usuario.DataCriacao,
                dataatualizacao = usuario.DataAtualizacao,
                idempresa = usuario.EmpresaPertencente.Id
            };
        }
    }
}
