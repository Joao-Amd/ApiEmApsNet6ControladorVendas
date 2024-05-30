using ApiControladorVendas.Dominio.AuthenticateService;
using ApiControladorVendas.Dominio.Usuarios;

namespace ApiControladorVendas.Dominio.Account
{
    public interface IAuthenticate
    {
        bool Authenticate(string email, string senha);
        string GenerateToken(int id, string email);
        Usuario GetUserByEmail(string email);
        bool UserExists(string email);
    }
}
