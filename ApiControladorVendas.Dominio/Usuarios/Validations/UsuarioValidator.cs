using ApiControladorVendas.Dominio.Usuarios.Dtos;
using FluentValidation;

namespace ApiControladorVendas.Dominio.Usuarios.Validations
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>
    {

        public UsuarioValidator()
        {
            _usuario();
            _email();
            _senha();
            _confirmarSenha();
        }

        private void _usuario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome deve ser obrigatório")
                .Matches("^[A-Za-zÀ-ÖØ-öø-ÿ\\s]+$").WithMessage("Nome deve conter apenas letras e espaços");
        }

        private void _email()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email deve ser obrigatório")
                .Length(5, 100).WithMessage("Email deve ter entre 5 e 100 caracteres")
                .EmailAddress().WithMessage("Email não é válido");
        }

        private void _senha()
        {
            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória")
                .Matches("[A-Z]").WithMessage("Senha deve conter pelo menos uma letra maiúscula")
                .Matches("[a-z]").WithMessage("Senha deve conter pelo menos uma letra minúscula")
                .Matches("[0-9]").WithMessage("Senha deve conter pelo menos um número")
                .Matches("[!@#$%^&*]").WithMessage("Senha deve conter pelo menos um caractere especial");
        }
        private void _confirmarSenha()
        {
            RuleFor(x => x.ConfirmacaoSenha)
                .Equal(x => x.Senha).WithMessage("A confirmação da senha não corresponde à senha digitada");
        }
    }
}

