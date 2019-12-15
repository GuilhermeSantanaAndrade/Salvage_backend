using System; 
using Microsoft.AspNetCore.Mvc;
using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
 

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    public class WorkflowsController : Controller
    {
        private readonly IAppWorkflowService _service; 
        public WorkflowsController(
            IAppWorkflowService service 
            )
        {
            _service = service; 
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Get([FromRoute] Guid guid)
        {
            try
            {
                var result = _service.SelecionarPorId(guid);

                if (result == null) return NotFound(new { data = result, Mensagens = "Workflow não encontrado" });
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
            var result = _service.ListarTodos();
            return Ok(new { data = result });
        }

        [HttpGet("{guid}/passos")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetPassos(Guid guid)
        {
            var workflow = _service.SelecionarPassos(guid);
            return Ok(new { data = workflow });
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

            _service.Deletar(guid);
            return Ok();
        } 

        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Atualizar([FromRoute] Guid guid, [FromBody] Workflow workflow)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            workflow.Guid = guid;

            try
            {
                _service.Atualizar(workflow);
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
        public IActionResult Incluir([FromBody] Workflow workflow)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            try
            {
                _service.Incluir(workflow);
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
