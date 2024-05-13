using ApiControladorVendas.Dominio.Clientes.Dtos;
using FluentValidation;

namespace ApiControladorVendas.Dominio.Clientes.Validations
{
    public class ClientesValidator : AbstractValidator<ClienteDto>
    {
        public ClientesValidator()
        {
            _nome();
            _cpf();
            _celular();
            _cep();
            _email();
            _endereco();
            _numero();
            _complemento();
            _bairro();
            _cidade();
            _estado();
        }

        private  void _nome()
        {
            RuleFor(x => x.Nome)
               .NotEmpty().WithMessage("Nome deve ser obrigatório")
               .Matches("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]+$").WithMessage("Nome deve conter apenas letras e espaços");
        }
        private void _cpf()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF deve  ser obrigatório")
                .IsValidCPF().WithMessage("CPF inválido");
        }
        private void _celular()
        {
            RuleFor(x => x.Celular)
        }
        private void _cep()
        {

        }
        private void _email()
        {

        }
        private void _endereco()
        {

        }
        private void _numero()
        {

        }
        private void _complemento()
        {

        }

        private void _bairro()
        {

        }
        private void _cidade()
        {

        }
        private void _estado()
        {

        }

    }
}
