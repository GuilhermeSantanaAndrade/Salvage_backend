using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salvage.Application.ViewModels;
using Salvage.Infra.EnvioEmail.Interfaces;

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {


        private readonly IEnvioEmail _service;
        public EmailsController(IEnvioEmail service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Incluir([FromBody] EmailViewModel email)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            try
            {
                var response = _service.EnviarPelaAPI(email.Destinatario, email.Assunto, email.BodyHTML);
                return Ok(new { data = response });

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