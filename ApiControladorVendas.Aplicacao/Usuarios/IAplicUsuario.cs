using ApiControladorVendas.Aplicacao.Usuarios.Dtos;
using ApiControladorVendas.Aplicacao.Usuarios.Views;

namespace ApiControladorVendas.Aplicacao.Usuarios
{
    public interface IAplicUsuario
    {
        UsuarioViewModel Recuperar(int id);
        List<UsuarioViewModel> RecuperarTodos();
        void Inserir(UsuarioDto dto);
        void Deletar(int id);
        UsuarioViewModel Alterar(int id, UsuarioDto dto);
    }
}
