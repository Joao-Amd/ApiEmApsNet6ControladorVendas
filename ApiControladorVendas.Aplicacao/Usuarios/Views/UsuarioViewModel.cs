using ApiControladorVendas.Dominio.Usuarios;

namespace ApiControladorVendas.Aplicacao.Usuarios.Views
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static UsuarioViewModel Novo(Usuario entidade)
        {
            if (entidade == null)
                return null;

            return new UsuarioViewModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Email = entidade.Email,
            };
        }
    }
}
