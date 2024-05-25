using ApiControladorVendas.Aplicacao.Clientes.Views;
using ApiControladorVendas.Clientes;
using ApiControladorVendas.Dominio.Clientes;
using ApiControladorVendas.Dominio.Clientes.Dtos;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;

namespace ApiControladorVendas.Aplicacao.Clientes
{
    public class AplicCliente : IAplicCliente
    {
        private readonly IRepCad<Cliente> _repCliente;
        private readonly IUnitOfWork _unitOfWork;

        public AplicCliente(IRepCad<Cliente> repCliente, IUnitOfWork unitOfWork)
        {
            _repCliente = repCliente;
            _unitOfWork = unitOfWork;
        }
        public ClienteViewModel Alterar(int id, ClienteDto dto)
        {
            var cliente = _repCliente.GetById(id);

            if (cliente == null)
                throw new Exception("Erro: Cliente não encontrado!");

            cliente.Alterar(dto.Nome, dto.Cpf, dto.Email, dto.Celular, dto.Cep, dto.Endereco,
                             dto.Numero, dto.Complemento, dto.Bairro, dto.Cidade, dto.Estado);

            _unitOfWork.Persistir();

            return ClienteViewModel.Novo(cliente);
        }

        public void Deletar(int id)
        {
            var cliente = _repCliente.GetById(id);

            if (cliente == null)
                throw new Exception("Erro: Cliente não encontrado!");

            _repCliente.Delete(cliente.Id);

            _unitOfWork.Persistir();
        }

        public void Inserir(ClienteDto dto)
        {
            try
            {
                var cliente = Cliente.Novo(dto.Nome, dto.Cpf, dto.Email, dto.Celular, dto.Cep, dto.Endereco,
                                         dto.Numero, dto.Complemento, dto.Bairro, dto.Cidade, dto.Estado);

                _repCliente.Inserir(cliente);

                _unitOfWork.Persistir();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }

        public ClienteViewModel Recuperar(int id)
        {
             var cliente = _repCliente.GetById(id);
            return ClienteViewModel.Novo(cliente);
        }

        public List<ClienteViewModel> RecuperarTodos()
        {
            var clientes = _repCliente.Get();

            return clientes.Select( x => ClienteViewModel.Novo(x)).ToList();
        }
    }
}
