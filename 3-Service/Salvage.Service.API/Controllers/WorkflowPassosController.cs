using System; 
using Microsoft.AspNetCore.Mvc;
using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
 
namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    public class WorkflowPassosController : Controller
    {

        private readonly IAppWorkflowPassoService _app;
        public WorkflowPassosController(
            IAppWorkflowPassoService app)
        {
            _app = app;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var result = _app.SelecionarPorId(id);

                if (result == null) return NotFound(new { data = result, Mensagens = "Etapa não encontrada" });
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
            var passos = _app.ListarTodos();
            return Ok(new { data = passos });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Deletar([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _app.Deletar(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Atualizar([FromRoute] int id, [FromBody] WorkflowPasso passo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            passo.Id = id;

            try
            {
                _app.Atualizar(passo);
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
        public IActionResult Incluir([FromBody] WorkflowPasso passo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {

                _app.Incluir(passo);
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
