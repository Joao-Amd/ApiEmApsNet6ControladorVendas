using ApiControladorVendas.Dominio.Account;
using ApiControladorVendas.Dominio.AuthenticateService;
using ApiControladorVendas.Dominio.AuthenticateService.Dtos;
using ApiControladorVendas.Repositorio.Contextos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApiControladorVendas.Repositorio.Authentications
{
    public class AuthTokenRefresh : IAuthTokenRefresh
    {
        private readonly Contexto _context;
        private readonly IAuthenticate _authenticator;
        private readonly IConfiguration _configuration;

        public AuthTokenRefresh(Contexto context, IAuthenticate authenticator, IConfiguration configuration)
        {
            _context = context;
            _authenticator = authenticator;
            _configuration = configuration;
        }

        public string CreateRefreshToken(string token)
        {
            var userToken = ExtractUserInfoFromToken(token);
            var tokenRefresh = _authenticator.GenerateToken(userToken.Id, userToken.Email);

            return tokenRefresh;
        }

        public UserTokenDto ExtractUserInfoFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["jwt:secretkey"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["jwt:issuer"],
                ValidAudience = _configuration["jwt:audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false 
            };

            try
            {
                if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = token.Substring("Bearer ".Length).Trim();
                }

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;

                var idClaim = principal.Claims.FirstOrDefault(c => c.Type == "id");
                var emailClaim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");

                if (idClaim == null || emailClaim == null)
                {
                    throw new SecurityTokenException("Token inválido: claims ausentes");
                }

                int id = int.Parse(idClaim.Value);
                string email = emailClaim.Value;

                var retorno = new UserTokenDto
                {
                    Id = id,
                    Email = email,
                };

                return retorno;
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Token inválido", ex);
            }
        }
    }
}
