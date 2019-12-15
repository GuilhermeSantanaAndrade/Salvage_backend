using System; 
using Microsoft.AspNetCore.Mvc;
using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
 

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    public class ContatosController : Controller
    {
        private readonly IAppContatoService _app;
        public ContatosController(IAppContatoService app)
        {
            _app = app;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)] 
        public IActionResult GetAll()
        {
            var result = _app.ListarTodos();

            if (result == null)
                return NotFound(new { data = result, Mensagens = "Nenhum contato cadastrado" });

            return Ok(new { data = result });
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Get(Guid guid)
        {
            try
            {

                var result = _app.SelecionarPorId(guid);

                if (result == null) return NotFound(new { data = result, Mensagens = "Contato não encontrado" });
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


        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Post([FromBody]Contato contato, Guid empresa)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {

                _app.Incluir(contato, empresa);
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

        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Put(Guid guid, [FromBody]Contato contato)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            contato.Guid = guid;

            try
            {
                _app.Atualizar(contato);
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

        [HttpDelete("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Delete([FromServices] Guid guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _app.Deletar(guid);
            return Ok();
        }
    }
}
