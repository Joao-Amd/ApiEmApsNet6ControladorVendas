using ApiControladorVendas.Aplicacao.ItemVendas;
using Microsoft.AspNetCore.Mvc;

namespace ApiControladorVendas.Api.Controllers.ItemVendas
{
    public class ItemVendaController : Controller
    {
        private readonly IAplicItemVenda _aplicItemVenda;
        public ItemVendaController(IAplicItemVenda aplicItemVenda)
        {
            _aplicItemVenda = aplicItemVenda;
        }

        
    }
}
