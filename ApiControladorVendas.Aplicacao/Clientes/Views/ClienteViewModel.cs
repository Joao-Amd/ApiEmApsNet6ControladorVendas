using ApiControladorVendas.Dominio.Clientes;

namespace ApiControladorVendas.Aplicacao.Clientes.Views
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static ClienteViewModel Novo(Cliente entidade)
        {
            if (entidade == null)
                return null;

            return new ClienteViewModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Cpf = entidade.Cpf,
                Celular = entidade.Celular,
                Cep = entidade.Cep,
                Email = entidade.Email,
                Endereco = entidade.Endereco,
                Numero = entidade.Numero,
                Complemento = entidade.Complemento,
                Bairro = entidade.Bairro,
                Cidade = entidade.Cidade,
                Estado = entidade.Estado
            };
        }
    }
}
