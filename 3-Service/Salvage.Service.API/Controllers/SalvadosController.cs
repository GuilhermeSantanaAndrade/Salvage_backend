using System; 
using Microsoft.AspNetCore.Mvc;
using Salvage.Application.Interfaces;
using Salvage.Application.ViewModels;
using Salvage.Domain.Entities;

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalvadosController : ControllerBase
    {

        private readonly IAppSalvadoService _app;
        public SalvadosController(
            IAppSalvadoService app)
        {
            _app = app;
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

                if (result == null) return Ok(new { data = result, Mensagens = "Salvado não encontrado" });
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

        [HttpGet("{guid}/historico")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetHistorico([FromRoute] Guid guid)
        {
            try
            {
                var result = _app.ListarHistorico(guid);

                if (result == null) return Ok(new { data = result, Mensagens = "Nenhum histórico encontrado" });
                return Ok(new { data = result });

            }
            catch (Domain.Validations.ExcecaoDeDominio ex)
            {
                return Ok(new { Mensagem = ex.Mensagens });
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
            return Ok(new { mensagem = "Salvado deletado com sucesso" });
        }

        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Atualizar([FromRoute] Guid guid, [FromBody] Salvado salvado)
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


        [HttpPut("{guid}/passos")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult AtualizarStatus([FromRoute] Guid guid, [FromBody] PassoViewModel passo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            { 
                _app.AtualizarPasso(guid, passo);
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
        public IActionResult Incluir([FromBody] Salvado salvado)
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
    }
}