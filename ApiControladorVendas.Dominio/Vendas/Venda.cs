using ApiControladorVendas.Dominio.Clientes;
using ApiControladorVendas.Dominio.ItemVendas;

namespace ApiControladorVendas.Dominio.Vendas
{
    public class Venda
    {
        public Venda(int idCliente, DateTime dataVenda, decimal totalVenda, string observacoes)
        {
            IdCliente = idCliente;
            DataVenda = dataVenda;
            TotalVenda = totalVenda;
            Observacoes = observacoes;
        }

        public int Id { get; private set; }
        public int IdCliente { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal TotalVenda { get; private set; }
        public string Observacoes { get; private set; }

        //

        public virtual ICollection<ItemVenda> ItensVendas { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        public static Venda Novo(int idCliente, DateTime dataVenda, decimal totalVenda, string observacoes)
        {
            return new Venda(idCliente, dataVenda, totalVenda, observacoes);
        }
        public  void Alterar(int idCliente, DateTime dataVenda, decimal totalVenda, string observacoes)
        {
            IdCliente = idCliente;
            DataVenda = dataVenda;
            TotalVenda = totalVenda;
            Observacoes = observacoes;
        }
    }
}
