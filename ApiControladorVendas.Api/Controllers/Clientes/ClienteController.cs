using ApiControladorVendas.Aplicacao.Clientes.Dtos;
using ApiControladorVendas.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.Clientes
{
    public class ClienteController : Controller
    {
        private readonly IAplicCliente _aplicCliente;
        public ClienteController(IAplicCliente aplicCliente)
        {
            _aplicCliente = aplicCliente;
        }
        [HttpGet("{Id}")]
        public IActionResult RecuperarPorId(int id)
        {
            try
            {
                var cliente = _aplicCliente.Recuperar(id);
                return Ok(cliente);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("Recuperar/Todos/Clientes")]

        public IActionResult RecuperarClientes()
        {
            try
            {
                var clientes = _aplicCliente.RecuperarTodos();
                return Ok(clientes);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody] ClienteDto dto)
        {
            try
            {
                _aplicCliente.Inserir(dto);
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
                _aplicCliente.Deletar(id);
                return Ok("Registro deletado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut("Alterar")]
        public IActionResult Alterar(int id, [FromBody] ClienteDto dto)
        {
            try
            {
                _aplicCliente.Alterar(id, dto);
                return Ok("Registro alterado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }

}
