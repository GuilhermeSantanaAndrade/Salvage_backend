using Microsoft.AspNetCore.Mvc; 
using Salvage.Application.Interfaces; 
using Salvage.Domain.Entities; 
using System;
using System.Linq;

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [FiltroCustomizadoDeExcecao]
    [Produces("application/json")]
    public class GuincheirosController : ControllerBase
    {
        private readonly IAppGuincheiroService _service; 
        public GuincheirosController(
            IAppGuincheiroService service 
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

                if (result == null) return NotFound(new { data = result, Mensagens = "Guincheiro não encontrado" }); 
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
            return Ok(new { quantidade = result.Count(), data = result }); 
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
        public IActionResult Atualizar([FromRoute] Guid guid, [FromBody] Guincheiro guincheiro)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            guincheiro.Guid = guid;

            try
            { 
                _service.Atualizar(guincheiro);
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
        public IActionResult Incluir([FromBody] Guincheiro guincheiro)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try { 

                _service.Incluir(guincheiro);
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