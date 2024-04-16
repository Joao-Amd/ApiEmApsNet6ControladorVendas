using ApiControladorVendas.Dominio.Usuarios;

namespace ApiControladorVendas.Dominio.Account
{
    public interface IAuthenticate
    {
        bool Authenticate(string email, string senha);
        bool UserExists(string email);
        public string GenerateToken(int id, string email);
        public Usuario GetUserByEmail(string email);

    }
}
