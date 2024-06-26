﻿using ApiControladorVendas.Aplicacao.Vendas;
using ApiControladorVendas.Dominio.Vendas.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.Vendas
{
    [Route("Venda")]
    [Authorize]
    public class VendaController : Controller
    {
        private readonly IAplicVenda _aplicVenda;
        public VendaController(IAplicVenda aplicVenda)
        {
            _aplicVenda = aplicVenda;
        }

        [HttpGet("Recuperar/Vendas")]
        public IActionResult Recuperar()
        {
            try
            {
                return Ok(_aplicVenda.RecuperarTodos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            try
            {
                return Ok(_aplicVenda.Recuperar(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] VendaDto dto)
        {
            try
            {
                _aplicVenda.Inserir(dto);
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
                _aplicVenda.Deletar(id);
                return Ok("Registro deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
