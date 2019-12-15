using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Salvage.Domain.ValueObjects;

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpersController : ControllerBase
    {
        [HttpGet("tipopessoa")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetAllPessoa()
        {

            try
            {
                return Ok(new { tipo = MapearEnum<TipoPessoa>() });
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
        [HttpGet("tipoempresa")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult GetAllEmpresa()
        {

            try
            { 
                return Ok(new { tipo = MapearEnum<TipoEmpresa>() });
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

        private Dictionary<int, string> MapearEnum<T>()
        {
            if (!typeof(T).IsEnum) return null;

            return Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(i => (int)Convert.ChangeType(i, i.GetType()), t => t.ToString());
        }
    }
}