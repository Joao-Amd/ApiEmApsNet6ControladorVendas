using ApiControladorVendas.Aplicacao.ItemVendas.Views;
using ApiControladorVendas.Dominio.ItemVendas.Dtos;

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
