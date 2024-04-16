using ApiControladorVendas.Dominio.Account;
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Repositorio.Contextos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApiControladorVendas.Repositorio.Authentications
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly Contexto _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(Contexto context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public bool Authenticate(string email, string senha)
        {
            var usuario = _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (usuario == null)
                return false;

            using var hmac = new HMACSHA512(usuario.SenhaSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            for(int x = 0; x < computeHash.Length; x++)
            {
                if (computeHash[x] != usuario.SenhaHash[x])
                    return false;
            }
            return true;
        }

        public string GenerateToken(int id, string email)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_configuration["jwt:secretkey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //var expiration = DateTime.UtcNow.AddHours(2);
            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Usuario GetUserByEmail(string email)
        {
            return _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public bool UserExists(string email)
        {
            var usuario = _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (usuario == null)
                return false;

            return true;
        }
    }
}
