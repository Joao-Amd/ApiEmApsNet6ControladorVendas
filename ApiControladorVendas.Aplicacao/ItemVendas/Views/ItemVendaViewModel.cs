using ApiControladorVendas.Dominio.ItemVendas;
using ApiControladorVendas.Dominio.Itens;
using ApiControladorVendas.Dominio.Vendas;

namespace ApiControladorVendas.Aplicacao.ItemVendas.Views
{
    public class ItemVendaViewModel
    {
        public int Id { get; private set; }
        public int IdVenda { get; private set; }
        public int IdItem { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Subtotal { get; private set; }
        public virtual Item Item { get; private set; }
        public virtual Venda Venda { get; private set; }


        public static ItemVendaViewModel Novo(ItemVenda itemVenda)
        {
            return new ItemVendaViewModel 
            { 
                Id = itemVenda.Id,
                IdItem = itemVenda.IdItem,
                IdVenda = itemVenda.IdVenda,
                Quantidade = itemVenda.Quantidade,
                Subtotal = itemVenda.Subtotal,
                Item = itemVenda.Item,
                Venda = itemVenda.Venda
           };
        }
    }
}
