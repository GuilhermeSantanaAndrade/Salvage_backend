using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Service.API.ViewModels;

namespace Salvage.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IAppUsuarioService _app;
        public UsuariosController(
            IAppUsuarioService app)
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

                if (result == null) return Ok(new { data = result, Mensagens = "Usuário não encontrado" });
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

        [HttpPost("acesso")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 403)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Acesso([FromBody] AcessoViewModel acesso)
        {
            try
            {
                var result = _app.SelecionarPorLoginSenha(acesso.Login, acesso.Senha);

                if (result == null) return Ok(new { data = result, Mensagens = "Usuário ou senha inválidos" });
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

        [HttpGet("login")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Login([FromBody] string login)
        {
            try
            {
                var result = _app.SelecionarPorLogin(login);

                if (result == null) return Ok(new { data = result, Mensagens = "Usuário ou senha inválidos" });
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

        [HttpDelete("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Deletar([FromRoute] Guid guid)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _app.Deletar(guid);
            return Ok();
        }

        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public IActionResult Atualizar([FromRoute] Guid guid, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            usuario.Guid = guid;

            try
            {
                _app.Atualizar(usuario);
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
        public IActionResult Incluir([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {

                _app.Incluir(usuario);
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