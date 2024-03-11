using ApiControladorVendas.Aplicacao.ItemVendas.Dtos;
using ApiControladorVendas.Aplicacao.ItemVendas.Views;
using ApiControladorVendas.Dominio.Vendas;

namespace ApiControladorVendas.Aplicacao.ItemVendas
{
    public interface IAplicItemVenda
    {
        void Inserir(int idVenda, ItemVendaDto dto);
        void Deletar(int id);
        ItemVendaViewModel Alterar(int id, ItemVendaDto dto);
        ItemVendaViewModel Recuperar(int id);
    }
}
