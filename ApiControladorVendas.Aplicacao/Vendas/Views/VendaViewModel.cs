using ApiControladorVendas.Aplicacao.ItemVendas.Views;
using ApiControladorVendas.Dominio.ItemVendas;
using ApiControladorVendas.Dominio.Vendas;

namespace ApiControladorVendas.Aplicacao.Vendas.Views
{
    public class VendaViewModel
    {
        public int Id { get; private set; }
        public int IdCliente { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal TotalVenda { get; private set; }
        public string Observacoes { get; private set; }
        public List<ItemVendaViewModel> ItensVendas { get; set; }

        public static VendaViewModel Novo(Venda entidade)
        {
            return new VendaViewModel
            {
                Id = entidade.Id,
                IdCliente = entidade.IdCliente,
                DataVenda = entidade.DataVenda,
                TotalVenda = entidade.TotalVenda,
                Observacoes = entidade.Observacoes,
                ItensVendas = entidade != null? entidade.ItensVendas.Select(x => ItemVendaViewModel.Novo(x)).ToList() : null
            };
        }
    }
}
