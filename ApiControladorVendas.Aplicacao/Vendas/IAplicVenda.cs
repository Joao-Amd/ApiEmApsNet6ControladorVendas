using ApiControladorVendas.Aplicacao.Vendas.Views;
using ApiControladorVendas.Dominio.Vendas.Dtos;

namespace ApiControladorVendas.Aplicacao.Vendas
{
    public interface IAplicVenda
    {
        VendaViewModel Recuperar(int id);
        List<VendaViewModel> RecuperarTodos();
        void Inserir(VendaDto dto);
        void Deletar(int id);
    }
}
