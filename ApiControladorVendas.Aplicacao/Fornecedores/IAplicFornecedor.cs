using ApiControladorVendas.Aplicacao.Fornecedores.Dtos;
using ApiControladorVendas.Aplicacao.Fornecedores.Views;

namespace ApiControladorVendas.Aplicacao.Fornecedores
{
    public interface IAplicFornecedor
    {
        FornecedorViewModel Recuperar(int id);
        List<FornecedorViewModel> RecuperarFornecedores();
        void Inserir(FornecedoreDto dto);
        void Deletar(int id);
        FornecedorViewModel Alterar(int id, FornecedoreDto dto);
    }
}
