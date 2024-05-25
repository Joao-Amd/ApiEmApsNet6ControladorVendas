using ApiControladorVendas.Aplicacao.ItemVendas;
using ApiControladorVendas.Dominio.ItemVendas.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.ItemVendas
{
    [Route("ItemVenda")]
    [Authorize]
    public class ItemVendaController : Controller
    {
        private readonly IAplicItemVenda _aplicItemVenda;
        public ItemVendaController(IAplicItemVenda aplicItemVenda)
        {
            _aplicItemVenda = aplicItemVenda;
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            try
            {
                return Ok(_aplicItemVenda.Recuperar(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }       

        [HttpPost]
        public IActionResult Inserir(int idVenda, ItemVendaDto dto)
        {
            try
            {
                _aplicItemVenda.Inserir(idVenda, dto);
                return Ok("Registro inserido com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _aplicItemVenda.Deletar(id);
                return Ok("Registro deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
