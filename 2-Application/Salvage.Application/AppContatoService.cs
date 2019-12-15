using System;
using System.Collections.Generic;
using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Application
{
    public class AppContatoService : IAppContatoService
    {
        private readonly IContatoService _service;
        private readonly IBaseService<Empresa> _empresaService;

        public AppContatoService(IContatoService service, IBaseService<Empresa> empresaService)
        {
            _service = service;
            _empresaService = empresaService;
        }
        public void Atualizar(Contato entidade)
        {
            _service.Atualizar(entidade);
        }

        public void Deletar(Guid id)
        {
            _service.Deletar(id);
        }

        public void Incluir(Contato entidade, Guid empresaGuid)
        {
            var empresa = _empresaService.SelecionarPorId(empresaGuid);
            _service.Incluir(entidade, empresa);
        }

        public IEnumerable<Contato> ListarTodos()
        {
            return _service.ListarTodos();
        }

        public Contato SelecionarPorId(Guid id)
        {
            return _service.SelecionarPorId(id);
        }
    }
}
