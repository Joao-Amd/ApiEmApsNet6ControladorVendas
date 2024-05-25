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
        Task<RefreshToken> CreateRefreshToken(int userId);
        Task<RefreshToken> GetRefreshToken(byte[] token);
        Task<bool> ValidateRefreshToken(byte[] token, int userId);
        Task InvalidateRefreshToken(byte[] token);
    }
}
