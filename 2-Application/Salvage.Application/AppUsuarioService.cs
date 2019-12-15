using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Application
{
    public class AppUsuarioService : IAppUsuarioService
    {
        private readonly IUsuarioService _service;
        public AppUsuarioService(IUsuarioService service)
        {
            _service = service;
        }
        public void Atualizar(Usuario usuario)
        {
            _service.Atualizar(usuario);
        }

        public void Deletar(Guid guid)
        {
            _service.Deletar(guid);
        }

        public void Incluir(Usuario usuario)
        {
            _service.Incluir(usuario);
        }

        public IEnumerable<Usuario> SelecionarPorEmpresa(int idEmpresa)
        {
            return _service.SelecionarPorEmpresa(idEmpresa);
        }

        public Usuario SelecionarPorId(Guid guid)
        {
            return _service.SelecionarPorId(guid);
        }

        public Usuario SelecionarPorLogin(string login)
        {
            return _service.SelecionarPorLogin(login);
        }

        public Usuario SelecionarPorLoginSenha(string login, string senha)
        {
            return _service.SelecionarPorLoginSenha(login, senha);
        }
    }
}
