using ApiControladorVendas.Dominio.AuthenticateService.Dtos;

namespace ApiControladorVendas.Dominio.AuthenticateService
{
    public interface IAuthTokenRefresh
    {
        string CreateRefreshToken(string token);
        UserTokenDto ExtractUserInfoFromToken(string token);
    }
}
