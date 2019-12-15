using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repositorio;

        public UsuarioService(IUsuarioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void Atualizar(Usuario usuario)
        {
            _repositorio.Atualizar(usuario);
        }

        public void Deletar(Guid guid)
        {
            _repositorio.Deletar(guid);
        }

        public void Incluir(Usuario usuario)
        {
            _repositorio.Incluir(usuario);
        }

        public IEnumerable<Usuario> SelecionarPorEmpresa(int idEmpresa)
        {
            return _repositorio.SelecionarPorEmpresa(idEmpresa);
        }

        public Usuario SelecionarPorId(Guid guid)
        {
            return _repositorio.SelecionarPorId(guid);
        }

        public Usuario SelecionarPorLogin(string login)
        {
            return _repositorio.SelecionarPorLogin(login);
        }

        public Usuario SelecionarPorLoginSenha(string login, string senha)
        {
            return _repositorio.SelecionarPorLoginSenha(login, senha);
        }
    }
}
