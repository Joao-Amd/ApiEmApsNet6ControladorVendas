using ApiControladorVendas.Dominio.Fornecedores;

namespace ApiControladorVendas.Aplicacao.Fornecedores.Views
{
    public class FornecedorViewModel
    {

        public int Id { get; set; }
        public string Nome { get; private set; }
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

        public static FornecedorViewModel Novo(Fornecedor entidade)
        {
            if (entidade == null)
                return null;

            return new FornecedorViewModel
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Cnpj = entidade.Cnpj,
                Email = entidade.Email,
                Celular = entidade.Celular,
                Cep = entidade.Cep,
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
