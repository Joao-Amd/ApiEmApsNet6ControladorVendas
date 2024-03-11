using ApiControladorVendas.Aplicacao.ItemVendas.Dtos;
using ApiControladorVendas.Aplicacao.ItemVendas.Views;
using ApiControladorVendas.Dominio.ItemVendas;
using ApiControladorVendas.Dominio.Itens;
using ApiControladorVendas.Dominio.Vendas;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;

namespace ApiControladorVendas.Aplicacao.ItemVendas
{
    public class AplicItemVenda : IAplicItemVenda
    {
        private readonly IRepCad<ItemVenda> _repItemVenda;
        private readonly IRepCad<Venda> _repVenda;
        private readonly IRepCad<Item> _repItem;
        private readonly IUnitOfWork _unitOfWork;

        public AplicItemVenda(IRepCad<ItemVenda> repItemVenda, IUnitOfWork unitOfWork, IRepCad<Item> repItem, IRepCad<Venda> repVenda)
        {
            _repItemVenda = repItemVenda;
            _unitOfWork = unitOfWork;
            _repItem = repItem;
            _repVenda = repVenda;
        }
        public ItemVendaViewModel Alterar(int id, ItemVendaDto dto)
        {
            var item = _repItem.GetById(dto.IdItem);

            var itemVenda = _repItemVenda.GetById(id);

            itemVenda.Alterar(item, dto.Quantidade);

            _unitOfWork.Persistir();

            return ItemVendaViewModel.Novo(itemVenda);
        }

        public void Deletar(int id)
        {
            _repItemVenda.Delete(id);

            _unitOfWork.Persistir();
        }

        public void Inserir(int idVenda, ItemVendaDto dto)
        {
            try
            {
                var item = _repItem.GetById(dto.IdItem);

                var venda = _repVenda.GetById(idVenda);

                var itemVenda = ItemVenda.Novo(item, dto.Quantidade);

                venda.InserirItemVenda(itemVenda);

                _repVenda.Inserir(venda);

                _unitOfWork.Persistir();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ItemVendaViewModel Recuperar(int id)
        {
            var itemVenda = _repItemVenda.GetById(id);
            return ItemVendaViewModel.Novo(itemVenda);
        }
    }
}
