using ApiControladorVendas.Aplicacao.Fornecedores.Dtos;
using ApiControladorVendas.Aplicacao.Fornecedores;
using Microsoft.AspNetCore.Mvc;
using ApiControladorVendas.Aplicacao.Itens;
using ApiControladorVendas.Aplicacao.Itens.Dtos;

namespace ApiControladorVendas.Api.Controllers.Itens
{
    public class ItemController : Controller
    {
        private readonly IAplicItem _aplicItem;
        public ItemController(IAplicItem aplicItem)
        {
            _aplicItem = aplicItem;
        }

        [HttpGet("{Id}")]
        public IActionResult RecuperarPorId(int id)
        {
            try
            {
                var item = _aplicItem.Recuperar(id);
                return Ok(item);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("Recuperar/Todos/Itens")]

        public IActionResult RecuperarItem()
        {
            try
            {
                var item = _aplicItem.RecuperarTodos();
                return Ok(item);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody] ItemDto dto)
        {
            try
            {
                _aplicItem.Inserir(dto);
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
                _aplicItem.Deletar(id);
                return Ok("Registro deletado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut("Alterar")]
        public IActionResult Alterar(int id, [FromBody] ItemDto dto)
        {
            try
            {
                _aplicItem.Alterar(id, dto);
                return Ok("Registro alterado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
