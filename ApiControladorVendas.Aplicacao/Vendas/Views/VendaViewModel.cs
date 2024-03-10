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
        public virtual ICollection<ItemVenda> ItensVendas { get; private set; }

        public static VendaViewModel Novo(Venda entidade)
        {
            return new VendaViewModel
            {
                Id = entidade.Id,
                IdCliente = entidade.IdCliente,
                DataVenda = entidade.DataVenda,
                TotalVenda = entidade.TotalVenda,
                Observacoes = entidade.Observacoes,
                ItensVendas = entidade.ItensVendas
            };
        }
    }
}
