using ApiControladorVendas.Dominio.Itens;
using ApiControladorVendas.Dominio.Vendas;

namespace ApiControladorVendas.Dominio.ItemVendas
{
    public class ItemVenda
    {
        public ItemVenda(Venda venda, Item item, int quantidade)
        {
            IdVenda = venda.Id;
            IdItem = item.Id;
            Quantidade = quantidade;
            Item = item;
        }

        public int Id { get; private set; }
        public int IdVenda { get; private set; }
        public int IdItem { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Subtotal { get; private set; }

        //

        public virtual Item Item { get; private set; }
        public virtual Venda Venda { get; private set; }

        public static ItemVenda Novo(Venda venda, Item item, int quantidade)
        {
            return new ItemVenda(venda, item, quantidade);
        }
        public void Alterar(Item item, int quantidade) 
        {
            Item = item;
            IdItem = item.Id;
            Quantidade = quantidade;

        }

        public void CalcularSubtotal()
        {
            Subtotal = Quantidade * Item.Preco;
        }
    }
}
