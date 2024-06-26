﻿using ApiControladorVendas.Aplicacao.Fornecedores;
using ApiControladorVendas.Dominio.Fornecedores.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.Fornecedores
{
    [Route("Fornecedor")]
    [Authorize]
    public class FornecedorController : Controller
    {

        private readonly IAplicFornecedor _aplicFornecedor;
        public FornecedorController(IAplicFornecedor aplicCliente)
        {
            _aplicFornecedor = aplicCliente;
        }
        [HttpGet("{Id}")]
        public IActionResult Recuperar(int id)
        {
            try
            {
                var fornecedor = _aplicFornecedor.Recuperar(id);
                return Ok(fornecedor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("Recuperar/Forncedores")]

        public IActionResult RecuperarClientes()
        {
            try
            {
                var fornecedor = _aplicFornecedor.RecuperarFornecedores();
                return Ok(fornecedor);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody] FornecedoreDto dto)
        {
            try
            {
                _aplicFornecedor.Inserir(dto);
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
                _aplicFornecedor.Deletar(id);
                return Ok("Registro deletado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut("Alterar")]
        public IActionResult Alterar(int id, [FromBody] FornecedoreDto dto)
        {
            try
            {
                _aplicFornecedor.Alterar(id, dto);
                return Ok("Registro alterado com sucesso!");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
