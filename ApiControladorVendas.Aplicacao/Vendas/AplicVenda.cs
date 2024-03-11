using ApiControladorVendas.Aplicacao.ItemVendas;
using ApiControladorVendas.Aplicacao.Vendas.Dtos;
using ApiControladorVendas.Aplicacao.Vendas.Views;
using ApiControladorVendas.Dominio.ItemVendas;
using ApiControladorVendas.Dominio.Vendas;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ApiControladorVendas.Aplicacao.Vendas
{
    public class AplicVenda : IAplicVenda
    {
        private readonly IRepCad<Venda> _repVenda;
        private readonly IRepCad<ItemVenda> _repItemVenda;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAplicItemVenda _aplicItemVenda;

        public AplicVenda(IRepCad<Venda> repVenda, IUnitOfWork unitOfWork, IRepCad<ItemVenda> repItemVenda, IAplicItemVenda aplicItemVenda)
        {
            _repVenda = repVenda;
            _unitOfWork = unitOfWork;
            _repItemVenda = repItemVenda;
            _aplicItemVenda = aplicItemVenda;
        }

        public void Deletar(int id)
        {
            var venda = _repVenda.GetById(id);


            foreach (var itemVenda in venda.ItensVendas)
            {
                _repItemVenda.Delete(itemVenda.Id);
            }

            _repVenda.Delete(venda.Id);

            _unitOfWork.Persistir();
        }

        public void Inserir(VendaDto dto)
        {
            Venda.Novo(dto.IdCliente, dto.Observacoes);

            _unitOfWork.Persistir();
        }

        public VendaViewModel Recuperar(int id)
        {
            return VendaViewModel.Novo(_repVenda.GetById(id));
        }

        public List<VendaViewModel> RecuperarVenda()
        {
            var vendas = _repVenda.Get();

            return vendas.Select(x => VendaViewModel.Novo(x)).ToList();
        }
    }
}
