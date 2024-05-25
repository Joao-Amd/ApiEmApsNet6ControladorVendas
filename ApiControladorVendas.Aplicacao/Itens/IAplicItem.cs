using ApiControladorVendas.Aplicacao.Itens.Views;
using ApiControladorVendas.Dominio.Itens.Dtos;

namespace ApiControladorVendas.Aplicacao.Itens
{
    public interface IAplicItem
    {
        ItemViewModel Recuperar(int id);
        List<ItemViewModel> RecuperarItens();
        void Inserir(ItemDto dto);
        void Deletar(int id);
        ItemViewModel Alterar(int id, ItemDto dto);
    }
}
