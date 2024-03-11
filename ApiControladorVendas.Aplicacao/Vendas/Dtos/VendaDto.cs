using ApiControladorVendas.Dominio.ItemVendas;

namespace ApiControladorVendas.Aplicacao.Vendas.Dtos
{
    public class VendaDto
    {

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Observacoes { get; set; }
    }
}
