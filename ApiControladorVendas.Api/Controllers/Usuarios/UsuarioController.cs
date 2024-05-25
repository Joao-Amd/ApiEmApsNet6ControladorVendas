using ApiControladorVendas.Aplicacao.Usuarios;
using ApiControladorVendas.Dominio.Account;
using ApiControladorVendas.Dominio.Authentications.ViewModels;
using ApiControladorVendas.Dominio.Usuarios.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.Usuarios
{
    [ApiController]
    [Route("Usuario")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IAplicUsuario _aplicUsuario;
        public UsuarioController(IAuthenticate authenticateService, IAplicUsuario aplicaUsuario)
        {
            _authenticateService = authenticateService;
            _aplicUsuario = aplicaUsuario;
        }

        [AllowAnonymous]
        [HttpPost("Inserir")]
        public ActionResult<UserTokenViewModel> Inserir([FromBody] UsuarioDto dto)
        {
            try
            {
                var emailExiste = _authenticateService.UserExists(dto.Email);

                if (emailExiste)
                     throw new Exception("Este e-mail já possui um cadastro.");

                var usuario = _aplicUsuario.Inserir(dto);

                var token = "Bearer " + _authenticateService.GenerateToken(usuario.Id, usuario.Email);

                return new UserTokenViewModel
                {
                    Token = token
                };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public IActionResult Recuperar(int id)
        {
            try
            {
                var fornecedor = _aplicUsuario.Recuperar(id);
                return Ok(fornecedor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("Recuperar/Usuarios")]
        public IActionResult RecuperarUsuario()
        {
            try
            {
                var fornecedor = _aplicUsuario.RecuperarTodos();
                return Ok(fornecedor);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _aplicUsuario.Deletar(id);
                return Ok("Registro deletado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(int id, [FromBody] UsuarioDto dto)
        {
            try
            {
                _aplicUsuario.Alterar(id, dto);
                return Ok("Registro alterado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult<UserTokenViewModel> Login(LoginUsuarioDto dto)
        {
            try
            {
                var result = _authenticateService.Authenticate(dto.Email, dto.Senha);

                if(!result)
                    throw new Exception("Usuário ou senha inválido.");

                var usuario = _authenticateService.GetUserByEmail(dto.Email);

                var token = "Bearer " + _authenticateService.GenerateToken(usuario.Id, usuario.Email);

                 return new UserTokenViewModel
                {
                    Token = token
                };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
