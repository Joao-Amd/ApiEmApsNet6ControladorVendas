using ApiControladorVendas.Aplicacao.Usuarios.Views;
using ApiControladorVendas.Dominio.Usuarios.Dtos;

namespace ApiControladorVendas.Aplicacao.Usuarios
{
    public interface IAplicUsuario
    {
        UsuarioViewModel Recuperar(int id);
        List<UsuarioViewModel> RecuperarTodos();
        UsuarioViewModel Inserir(UsuarioDto dto);
        void Deletar(int id);
        UsuarioViewModel Alterar(int id, UsuarioDto dto);
    }
}
