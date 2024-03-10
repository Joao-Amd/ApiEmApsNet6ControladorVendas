using ApiControladorVendas.Dominio.Vendas;

namespace ApiControladorVendas.Dominio.Usuarios
{
    public class Usuario
    {
        public Usuario(string nome, string email, string senha, string nivelAcesso)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            NivelAcesso = nivelAcesso;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string NivelAcesso { get; private set; }

        public static  Usuario Novo(string nome, string email, string senha, string nivelAcesso)
        {
            return new Usuario(nome, email, senha, nivelAcesso);
        }

        public void Alterar(string nome, string email, string senha, string nivelAcesso)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            NivelAcesso = nivelAcesso;
        }
    }
}
