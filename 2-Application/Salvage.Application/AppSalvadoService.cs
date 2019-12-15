using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Salvage.Application.Interfaces;
using Salvage.Application.ViewModels;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;
using Salvage.Domain.ValueObjects;
using Salvage.Infra.EnvioEmail;
using Salvage.Infra.EnvioEmail.Interfaces;

namespace Salvage.Application
{
    public class AppSalvadoService : IAppSalvadoService
    {
        private readonly ISalvadoService _service;
        private readonly ISeguradoraService _seguradora;
        private readonly IGuincheiroService _guincheiro;
        private readonly IOficinaService _oficina;
        private readonly IPatioService _patio;
        private readonly IDespachanteService _despachante;
        private readonly IWorkflowPassoService _passo;
        private readonly IEnvioEmail _email;
        private readonly IUsuarioService _usuario;
        public AppSalvadoService(ISalvadoService service
            , IWorkflowPassoService passo
            , IEnvioEmail email
            , IUsuarioService usuario
            , ISeguradoraService seguradora
            , IGuincheiroService guincheiro
            , IOficinaService oficina
            , IPatioService patio
            , IDespachanteService despachante 
            ) 
        {
            _service = service;
            _passo = passo;
            _email = email;
            _usuario = usuario;
            _seguradora = seguradora;
            _guincheiro = guincheiro;
            _oficina = oficina;
            _patio = patio;
            _despachante = despachante; 
        }

        public void Atualizar(Salvado entidade)
        {
            _service.Atualizar(entidade);
        }

        public void AtualizarPasso(Guid guidSalvado, PassoViewModel passoVM)
        {
            var passoAtual = _passo.SelecionarPorId(passoVM.IdPasso);
            var salvado = _service.SelecionarPorId(guidSalvado);

            salvado.PassoEtapa = _passo.SelecionarPorId((int)salvado.PassoEtapa.Id);

            if (passoAtual.Ordem <= salvado.PassoEtapa.Ordem) return;

            var historico = new SalvadoHistorico();
            historico.DescricaoEvento = $"[Atualização][De {salvado.PassoEtapa.Descricao} para {passoAtual.Descricao} - {DateTime.Now}] ";
            historico.DescricaoEvento += passoVM.Observacao;
            historico.IdSalvado = (int) salvado.Id;
            historico.IdUsuario = passoVM.IdUsuario ?? (int) _usuario.SelecionarPorId((Guid)passoVM.GuidUsuario).Id;
            historico.DataEvento = DateTime.Now;

            salvado.PassoEtapa = passoAtual;

            //pegar o proximo passo 
            var passoFuturo = _passo.SelecionarProximoPasso(++passoAtual.Ordem, (int)passoAtual.Workflow.Id);
            if (passoFuturo != null)
            {
                int idEmpresa = _service.SelecionarIdDependendoTipoEmpresa(passoFuturo.TipoEmpresaResponsavel, salvado.Guid);
                (string header, string body, int status) retorno = EnviaEmailAcordoEmpresa(passoFuturo.TipoEmpresaResponsavel, idEmpresa, (int)passoFuturo.Id, passoFuturo.DescricaoParaFazer, salvado.Guid);
            }
            else
            {
                var html = EmailSendGrid.LayoutProcessoFinalizado(salvado);
                var seguradora = _seguradora.SelecionarPorId((int)salvado.Seguradora.Id); 
                _email.Envia(seguradora.Email, "Nenhuma ação necessária", html);
            }

            _service.IncluirHistorico(historico);
            _service.Atualizar(salvado);

        }

        private (string, string, int) EnviaEmailAcordoEmpresa(TipoEmpresa tipo, int idEmpresa, int passoId, string descricaoOQueFazer, Guid guidSalvado)
        {
            Empresa empresa = new Empresa();
            switch (tipo)
            {
                case TipoEmpresa.Seguradora:
                    empresa = _seguradora.SelecionarPorId(idEmpresa);
                    break;
                case TipoEmpresa.Guincheiro:
                    empresa = _guincheiro.SelecionarPorId(idEmpresa);
                    break;
                case TipoEmpresa.Despachante:
                    empresa = _despachante.SelecionarPorId(idEmpresa);
                    break;
                case TipoEmpresa.Patio:
                    empresa = _patio.SelecionarPorId(idEmpresa);
                    break;
                case TipoEmpresa.Oficina:
                    empresa = _oficina.SelecionarPorId(idEmpresa);
                    break; 
            }
            var link = $"https://engsalvage.azurewebsites.net/#/push/andamentoProcessoPush?guid={guidSalvado}&passo={passoId}";
            var html = EmailSendGrid.LayoutProximaAcao().Replace("{{nome}}",empresa.Nome).Replace("{{link}}", link).Replace("{{texto}}", descricaoOQueFazer);

            return _email.Envia(empresa.Email, "Ação Necessária", html).Result;
        }

        public void Deletar(Guid id)
        {
            _service.Deletar(id);
        }

        public void Incluir(Salvado entidade)
        {
            _service.Incluir(entidade);
        }

        public IEnumerable<SalvadoHistorico> ListarHistorico(Guid guidSalvado)
        {
            var salvado = _service.SelecionarPorId(guidSalvado);
            return _service.ListarHistorico((int)salvado.Id);
        }

        public IEnumerable<Salvado> ListarTodos()
        {
            return _service.ListarTodos();
        }

        public Salvado SelecionarPorId(Guid id)
        {
            return _service.SelecionarPorId(id);
        }

        public Salvado SelecionarPorPlaca(string placa)
        {
            return _service.SelecionarPorPlaca(placa);
        }
    }
}
