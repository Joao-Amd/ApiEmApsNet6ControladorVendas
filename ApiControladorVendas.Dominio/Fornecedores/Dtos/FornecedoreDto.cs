namespace ApiControladorVendas.Dominio.Fornecedores.Dtos
{
    public class FornecedoreDto
    {
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
    }
}
