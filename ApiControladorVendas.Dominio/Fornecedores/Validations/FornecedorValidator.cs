using ApiControladorVendas.Dominio.Fornecedores.Dtos;
using FluentValidation;

namespace ApiControladorVendas.Dominio.Fornecedores.Validations
{
    public class FornecedorValidator : AbstractValidator<FornecedoreDto>
    {
        public FornecedorValidator()
        {
            _nome();
            _cpf();
            _celular();
            _cep();
            _email();
            _endereco();
            _complemento();
            _bairro();
            _cidade();
            _estado();
        }

        private void _nome()
        {
            RuleFor(x => x.Nome)
               .NotEmpty().WithMessage("Nome deve ser obrigatório")
               .Matches("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]+$").WithMessage("Nome deve conter apenas letras e espaços");
        }
        private void _cpf()
        {
            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("Cnpj deve ser obrigatório")
                .IsValidCNPJ().WithMessage("Cnpj inválido");
        }
        private void _celular()
        {
            RuleFor(x => x.Celular)
                .NotEmpty().WithMessage("Celular deve ser obrigatório")
                .Matches("^\\(\\d{2}\\)\\s?\\d{4,5}-\\d{4}$").WithMessage("Formato de celular inválido");
        }
        private void _cep()
        {
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("CEP deve ser obrigatório")
                .Matches("^\\d{5}-\\d{3}$").WithMessage("Formato de CEP inválido");
        }
        private void _email()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email deve ser obrigatório")
                 .Length(5, 100).WithMessage("Email deve ter entre 5 e 100 caracteres")
                 .EmailAddress().WithMessage("Email não é válido");
        }
        private void _endereco()
        {
            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("Endereço deve ser obrigatório");
        }
        private void _complemento()
        {
            RuleFor(x => x.Complemento)
                .NotEmpty().WithMessage("Complemento deve ser obrigatório");
        }

        private void _bairro()
        {
            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Bairro deve ser obrigatório");
        }
        private void _cidade()
        {
            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade deve ser obrigatória");
        }
        private void _estado()
        {
            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Estado deve ser obrigatório")
                .Length(2).WithMessage("Estado deve conter exatamente dois caracteres");
        }
    }
}
