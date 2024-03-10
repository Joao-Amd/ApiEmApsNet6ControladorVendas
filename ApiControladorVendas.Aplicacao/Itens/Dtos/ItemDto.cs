using ApiControladorVendas.Dominio.Fornecedores;

namespace ApiControladorVendas.Aplicacao.Itens.Dtos
{
    public class ItemDto
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
