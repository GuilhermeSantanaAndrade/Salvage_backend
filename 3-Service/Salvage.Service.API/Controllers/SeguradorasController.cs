using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Salvage.Application;
using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguradorasController : ControllerBase
    {
        private readonly IAppSeguradoraService _app;
        private readonly IAppRelatoriosService _relatorio;
        public SeguradorasController(
            IAppSeguradoraService app, IAppRelatoriosService relatorio)
        {
            _app = app;
            _relatorio = relatorio;
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get([FromRoute] Guid guid)
        {
            try
            {
                var result = _app.SelecionarPorId(guid);

                if (result == null) return NotFound(new { data = result, Mensagens = "Seguradora não encontrada" });
                return Ok(new { data = result });

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return BadRequest(new { Mensagem = ex.Mensagens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagens = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetAll()
        {
            var salvados = _app.ListarTodos();
            return Ok(new { data = salvados });
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Deletar([FromRoute] Guid guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _app.Deletar(guid);
            return Ok(new { mensagem = "Seguradora deletada com sucesso" });
        }

        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Atualizar([FromRoute] Guid guid, [FromBody] Seguradora salvado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            salvado.Guid = guid;

            try
            {
                _app.Atualizar(salvado);
                return Ok();

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return BadRequest(new { Mensagem = ex.Mensagens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagens = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Incluir([FromBody] Seguradora salvado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            try
            {
                _app.Incluir(salvado);
                return Ok();

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return BadRequest(new { Mensagem = ex.Mensagens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagens = ex.Message });
            }
        }

        #region " RELATORIOS "

        [HttpGet("{guid}/relatorios/salvados/passos")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetSalvadosPorPasso([FromRoute] Guid guid)
        {
            try
            {
                var salvados = _relatorio.ListarSalvadosPorSeguradora(guid);

                var relatorio = salvados?.GroupBy(g => g.PassoEtapa.Descricao).Select(s => new { Descricao = s.Key, Quantidade = s.Count() });

                if (salvados == null) return Ok(new { Mensagens = "Seguradora não encontrada" });
                return Ok(new { data = relatorio });

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return BadRequest(new { Mensagem = ex.Mensagens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagens = ex.Message });
            }
        }
        [HttpGet("{guid}/relatorios/salvados/mes")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetSalvadosPorMes([FromRoute] Guid guid)
        {
            try
            {
                var salvados = _relatorio.ListarSalvadosPorSeguradora(guid);

                var relatorio = salvados?.GroupBy(g => g.DataAtualizacao.ToString("MM/yyyy") ).Select(s => new { MesAno = s.Key, Quantidade = s.Count() });

                if (salvados == null) return Ok(new { Mensagens = "Seguradora não encontrada" });
                return Ok(new { data = relatorio });

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return BadRequest(new { Mensagem = ex.Mensagens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagens = ex.Message });
            }
        }
        [HttpGet("{guid}/relatorios/salvados/passos/{passoId}/dia")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetSalvadosPorPassoDia([FromRoute] Guid guid, [FromRoute]int passoId)
        {
            try
            {
                var salvados = _relatorio.ListarSalvadosPorSeguradora(guid);

                var relatorio = salvados?.Where(p => p.PassoEtapa.Id == passoId)
                    ?.GroupBy(g => g.DataAtualizacao.ToString("dd/MM/yyyy"))
                    .Select(s => new { MesAno = s.Key, Quantidade = s.Count() });

                if (salvados == null) return Ok(new { Mensagens = "Seguradora não encontrada" });
                return Ok(new { data = relatorio });

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return BadRequest(new { Mensagem = ex.Mensagens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagens = ex.Message });
            }
        }
        [HttpGet("{guid}/relatorios/salvados/passos/{passoId}/mes")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetSalvadosPorPassoMes([FromRoute] Guid guid, [FromRoute]int passoId)
        {
            try
            {
                var salvados = _relatorio.ListarSalvadosPorSeguradora(guid);

                var relatorio = salvados?.Where(p => p.PassoEtapa.Id == passoId)
                    ?.GroupBy(g => g.DataAtualizacao.ToString("MM/yyyy"))
                    .Select(s => new { MesAno = s.Key, Quantidade = s.Count() });

                if (salvados == null) return Ok(new { Mensagens = "Seguradora não encontrada" });
                return Ok(new { data = relatorio });

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return BadRequest(new { Mensagem = ex.Mensagens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagens = ex.Message });
            }
        }
        #endregion
    }
}