using ApiControladorVendas.Aplicacao.Itens;
using ApiControladorVendas.Dominio.Itens.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.Itens
{
    [Route("Item")]
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IAplicItem _aplicItem;
        public ItemController(IAplicItem aplicItem)
        {
            _aplicItem = aplicItem;
        }

        [HttpGet("{Id}")]
        public IActionResult Recuperar(int id)
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

        [HttpGet("Recuperar/Itens")]

        public IActionResult RecuperarItem()
        {
            try
            {
                var item = _aplicItem.RecuperarItens();
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
