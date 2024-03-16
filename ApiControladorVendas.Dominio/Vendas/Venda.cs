using ApiControladorVendas.Dominio.Clientes;
using ApiControladorVendas.Dominio.ItemVendas;

namespace ApiControladorVendas.Dominio.Vendas
{
    public class Venda
    {
        public Venda(int idCliente, string observacoes)
        {
            IdCliente = idCliente;
            Observacoes = observacoes;
        }

        protected Venda() { }

        public int Id { get; private set; }
        public int IdCliente { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal TotalVenda { get; private set; }
        public string Observacoes { get; private set; }

        //

        public virtual List<ItemVenda> ItensVendas { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        public static Venda Novo(int idCliente, string observacoes)
        {
            return new Venda(idCliente, observacoes);
        }
        public void Alterar(int idCliente, string observacoes)
        {
            IdCliente = idCliente;
            Observacoes = observacoes;
        }

        public void InserirItemVenda(ItemVenda itemVenda)
        {
            itemVenda.CalcularSubtotal();

            this.ItensVendas.Add(itemVenda);
            _calcularTotalVenda();
        }
        private void _calcularTotalVenda()
        {
            TotalVenda = ItensVendas.Sum(x => x.Subtotal);
        }
        public void RemoverItemVenda(ItemVenda itemVenda)
        {
            itemVenda.CalcularSubtotal();

            this.ItensVendas.Remove(itemVenda);
            _calcularTotalVenda();
        }
    }
}
