using ApiControladorVendas.Dominio.Vendas;

namespace ApiControladorVendas.Dominio.Clientes
{
    public class Cliente 
    {
        public Cliente(string nome, string cpf, string email, string celular,
                   string cep, string endereco, int numero, string complemento,
                   string bairro, string cidade, string estado)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Celular = celular;
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        protected Cliente() { }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        //public virtual Venda Venda { get; set; }
        public static Cliente Novo(string nome, string cpf, string email, string celular,
                   string cep, string endereco, int numero, string complemento,
                   string bairro, string cidade, string estado)
        {
            return new Cliente( nome, cpf, email, celular, cep, endereco, numero, complemento, bairro, cidade, estado);
        }

        public void Alterar(string nome, string cpf, string email, string celular,
                   string cep, string endereco, int numero, string complemento,
                   string bairro, string cidade, string estado)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Celular = celular;
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
