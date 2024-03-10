using ApiControladorVendas.Aplicacao.Usuarios;
using ApiControladorVendas.Aplicacao.Usuarios.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.Usuarios
{
    public class UsuarioController : Controller
    {
        private readonly IAplicUsuario _aplicUsuario;
        public UsuarioController(IAplicUsuario aplicCliente)
        {
            _aplicUsuario = aplicCliente;
        }
        [HttpGet("{Id}")]
        public IActionResult RecuperarPorId(int id)
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

        [HttpGet("Recuperar/Todos/Usuarios")]

        public IActionResult RecuperarUsuario()
        {
            try
            {
                var fornecedor = _aplicUsuario.RecuperarUsuario();
                return Ok(fornecedor);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody] UsuarioDto dto)
        {
            try
            {
                _aplicUsuario.Inserir(dto);
                return Ok("Registro Inserido com sucesso!");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
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
    }
}
