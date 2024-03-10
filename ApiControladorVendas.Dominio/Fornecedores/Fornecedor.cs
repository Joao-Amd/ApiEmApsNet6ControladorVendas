namespace ApiControladorVendas.Dominio.Fornecedores
{
    public class Fornecedor
    {
        public Fornecedor(string nome, string cnpj, string email, string celular,
                      string cep, string endereco, int numero, string complemento,
                      string bairro, string cidade, string estado)
        {
            Nome = nome;
            Cnpj = cnpj;
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

        public int Id { get; private set; }
        public string Nome { get;  set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string Celular { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public static Fornecedor Novo(string nome, string cnpj, string email, string celular,
                      string cep, string endereco, int numero, string complemento,
                      string bairro, string cidade, string estado)
        {
            return new Fornecedor(nome, cnpj, email,  celular,
                       cep,  endereco,  numero,  complemento,
                       bairro,  cidade,  estado);
        }

        public void  Alterar(string nome, string cnpj, string email, string celular,
                      string cep, string endereco, int numero, string complemento,
                      string bairro, string cidade, string estado)
        {
            Nome = nome;
            Cnpj = cnpj;
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
