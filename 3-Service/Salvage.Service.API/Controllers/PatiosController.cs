using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Salvage.Application.Interfaces;
using Salvage.Application.ViewModels;
using Salvage.Domain.Entities;

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [FiltroCustomizadoDeExcecao]
    [Produces("application/json")]
    public class PatiosController : ControllerBase
    {
        private readonly IAppPatioService _service;
        public PatiosController(
            IAppPatioService service
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
                var patio = _service.SelecionarPorId(guid);

                if (patio == null) return NotFound(new { data = patio, Mensagens = "Patio não encontrado" });
                return Ok(new { data = patio });

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
            var patios = _service.ListarTodos();
            return Ok(new { quantidade = patios.Count(), data = patios });
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Deletar([FromRoute] Guid guid)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            _service.Deletar(guid);
            return Ok();
        }

        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)] 
        public IActionResult Atualizar([FromRoute] Guid guid, [FromBody] Patio patio)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            patio.Guid = guid;

            try
            {
                _service.Atualizar(patio);
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
        public IActionResult Incluir([FromBody] Patio patio)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            try
            {
                _service.Incluir(patio);
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