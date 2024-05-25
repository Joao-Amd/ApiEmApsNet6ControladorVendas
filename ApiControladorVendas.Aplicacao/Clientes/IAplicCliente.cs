using ApiControladorVendas.Aplicacao.Clientes.Views;
using ApiControladorVendas.Dominio.Clientes.Dtos;

namespace ApiControladorVendas.Clientes
{
    public interface IAplicCliente
    {
        ClienteViewModel Recuperar(int id);
        List<ClienteViewModel> RecuperarTodos();
        void Inserir(ClienteDto dto);
        void Deletar(int id);
        ClienteViewModel Alterar(int id, ClienteDto dto);
    }
}
