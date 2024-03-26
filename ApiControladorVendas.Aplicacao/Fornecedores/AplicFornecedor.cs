using ApiControladorVendas.Aplicacao.Fornecedores.Dtos;
using ApiControladorVendas.Aplicacao.Fornecedores.Views;
using ApiControladorVendas.Dominio.Fornecedores;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;

namespace ApiControladorVendas.Aplicacao.Fornecedores
{
    public class AplicFornecedor : IAplicFornecedor
    {
        private readonly IRepCad<Fornecedor> _repFornecedor;
        private readonly IUnitOfWork _unitOfWork;

        public AplicFornecedor(IRepCad<Fornecedor> repFornecedor, IUnitOfWork unitOfWork)
        {
            _repFornecedor = repFornecedor;
            _unitOfWork = unitOfWork;
        }

        public FornecedorViewModel Alterar(int id, FornecedoreDto dto)
        {
            var fornecedor = _repFornecedor.GetById(id);

            if (fornecedor == null)
                throw new Exception("Erro: Fornecedor não encontrado!");

            fornecedor.Alterar(dto.Nome, dto.Cnpj, dto.Email, dto.Celular, dto.Cep, dto.Endereco,
                            dto.Numero, dto.Complemento, dto.Bairro, dto.Cidade, dto.Estado);

            _unitOfWork.Persistir();

            return FornecedorViewModel.Novo(fornecedor);
        }

        public void Deletar(int id) 
        {
            var fornecedor = _repFornecedor.GetById(id);

            if (fornecedor == null)
                throw new Exception("Erro: Fornecedor não encontrado!");

            _repFornecedor.Delete(fornecedor.Id);

            _unitOfWork.Persistir();
        }

        public void Inserir(FornecedoreDto dto)
        {
            try
            {
                var fronecedor = Fornecedor.Novo(dto.Nome, dto.Cnpj, dto.Email, dto.Celular, dto.Cep, dto.Endereco,
                                         dto.Numero, dto.Complemento, dto.Bairro, dto.Cidade, dto.Estado);

                _repFornecedor.Inserir(fronecedor);

                _unitOfWork.Persistir();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public FornecedorViewModel Recuperar(int id)
        {
            var fornecedor = _repFornecedor.GetById(id);
            return FornecedorViewModel.Novo(fornecedor);
        }

        public List<FornecedorViewModel> RecuperarFornecedores()
        {
            var fornecedor = _repFornecedor.Get();

            return fornecedor.Select(x => FornecedorViewModel.Novo(x)).ToList();
        }
    }
}
