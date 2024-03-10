using ApiControladorVendas.Aplicacao.Itens.Dtos;
using ApiControladorVendas.Aplicacao.Itens.Views;
using ApiControladorVendas.Dominio.Fornecedores;
using ApiControladorVendas.Dominio.Itens;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;

namespace ApiControladorVendas.Aplicacao.Itens
{
    public class AplicItem : IAplicItem
    {
        private readonly IRepCad<Item> _repItem;
        private readonly IRepCad<Fornecedor> _repFornecedor;
        private readonly IUnitOfWork _unitOfWork;

        public AplicItem(IUnitOfWork unitOfWork, IRepCad<Item> repItem, IRepCad<Fornecedor> repFornecedor)
        {
            _unitOfWork = unitOfWork;
            _repItem = repItem;
            _repFornecedor = repFornecedor;
        }
        public ItemViewModel Alterar(int id, ItemDto dto)
        {
            var item = _repItem.GetById(id);

            var fornecedor =  _repFornecedor.GetById(dto.IdFornecedor);

            item.Alterar(dto.Descricao, dto.Preco, dto.Quantidade, fornecedor);

            _unitOfWork.Persistir();

            return ItemViewModel.Novo(item);
        }

        public void Deletar(int id)
        {
            _repItem.Delete(id);

            _unitOfWork.Persistir();
        }

        public void Inserir(ItemDto dto)
        {
            try
            {
                var fornecedor = _repFornecedor.GetById(dto.IdFornecedor);

                var item = Item.Novo(dto.Descricao, dto.Preco, dto.Quantidade, fornecedor);

                _repItem.Inserir(item);

                _unitOfWork.Persistir();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ItemViewModel Recuperar(int id)
        {
            var item = _repItem.GetById(id);
            return ItemViewModel.Novo(item);
        }

        public List<ItemViewModel> RecuperarItem()
        {
            var item = _repItem.Get();

            return item.Select(x => ItemViewModel.Novo(x)).ToList();
        }
    }
}
