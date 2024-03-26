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


        public static ItemVendaViewModel Novo(ItemVenda entidade)
        {
            if (entidade == null)
                return null;

            return new ItemVendaViewModel 
            { 
                Id = entidade.Id,
                IdItem = entidade.IdItem,
                IdVenda = entidade.IdVenda,
                Quantidade = entidade.Quantidade,
                Subtotal = entidade.Subtotal,
                Item = entidade.Item,
                Venda = entidade.Venda
           };
        }
    }
}
