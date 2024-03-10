using ApiControladorVendas.Aplicacao.Clientes.Dtos;
using ApiControladorVendas.Aplicacao.Clientes.Views;

namespace ApiControladorVendas.Clientes
{
    public interface IAplicCliente
    {
        ClienteViewModel Recuperar(int id);
        List<ClienteViewModel> RecuperarClientes();
        void Inserir(ClienteDto dto);
        void Deletar(int id);
        ClienteViewModel Alterar(int id, ClienteDto dto);
    }
}
