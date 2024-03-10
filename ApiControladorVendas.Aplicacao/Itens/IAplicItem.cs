using ApiControladorVendas.Aplicacao.Itens.Dtos;
using ApiControladorVendas.Aplicacao.Itens.Views;
using ApiControladorVendas.Aplicacao.Usuarios.Dtos;
using ApiControladorVendas.Aplicacao.Usuarios.Views;

namespace ApiControladorVendas.Aplicacao.Itens
{
    public interface IAplicItem
    {
        ItemViewModel Recuperar(int id);
        List<ItemViewModel> RecuperarItem();
        void Inserir(ItemDto dto);
        void Deletar(int id);
        ItemViewModel Alterar(int id, ItemDto dto);
    }
}
