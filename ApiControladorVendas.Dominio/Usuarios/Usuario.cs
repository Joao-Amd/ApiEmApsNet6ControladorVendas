using ApiControladorVendas.Dominio.Vendas;

namespace ApiControladorVendas.Dominio.Usuarios
{
    public class Usuario
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        protected Usuario() { }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public byte[] SenhaHash { get; private set; }
        public byte[] SenhaSalt { get; private set; }

        public static Usuario Novo(string nome, string email)
        {
            return new Usuario(nome, email);
        }

        public void Alterar(string nome, string email, byte[] senhaHash)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
        }

        public void AlterarSenha(byte[] senhaHash, byte[] senhaSalt)
        {
            SenhaHash = senhaHash;
            SenhaSalt = senhaSalt;
        }
    }
}
