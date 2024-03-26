using ApiControladorVendas.Dominio.Fornecedores;
using ApiControladorVendas.Dominio.Itens;

namespace ApiControladorVendas.Aplicacao.Itens.Views
{
    public class ItemViewModel
    {
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
        public int IdFornecedor { get; private set; }
        public virtual Fornecedor Fornecedor { get; private set; }

        public static ItemViewModel Novo(Item entidade)
        {
            if (entidade == null)
                return null;

            return new ItemViewModel
            {
                Descricao = entidade.Descricao,
                Preco = entidade.Preco,
                Quantidade = entidade.Quantidade,
                IdFornecedor = entidade.IdFornecedor,
                Fornecedor = entidade.Fornecedor
            };
        }
    }
}
