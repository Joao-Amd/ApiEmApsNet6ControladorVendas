namespace ApiControladorVendas.Dominio.Account
{
    public interface IAuthenticate
    {
        bool AuthenticateAsync(string email, string senha);
        bool UserExists(string email);
        public string GenerateToken(int id, string email);

    }
}
