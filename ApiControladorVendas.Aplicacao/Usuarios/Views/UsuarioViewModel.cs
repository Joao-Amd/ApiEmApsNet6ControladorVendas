using ApiControladorVendas.Dominio.Usuarios;

namespace ApiControladorVendas.Aplicacao.Usuarios.Views
{
    public class UsuarioViewModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string NivelAcesso { get; private set; }


        public static UsuarioViewModel Novo(Usuario entidade)
        {
            if (entidade == null)
                return null;

            return new UsuarioViewModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Email = entidade.Email,
                Senha = entidade.Senha,
                NivelAcesso = entidade.NivelAcesso
            };
        }
    }
}
