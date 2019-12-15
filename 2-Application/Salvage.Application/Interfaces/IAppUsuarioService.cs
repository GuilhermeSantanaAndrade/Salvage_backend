using Salvage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Application.Interfaces
{
    public interface IAppUsuarioService
    {
        void Deletar(Guid guid);
        void Incluir(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario SelecionarPorId(Guid guid);
        IEnumerable<Usuario> SelecionarPorEmpresa(int idEmpresa);
        Usuario SelecionarPorLogin(string login);
        Usuario SelecionarPorLoginSenha(string login, string senha);
    }
}
