using System.ComponentModel.DataAnnotations;

namespace ApiControladorVendas.Dominio.Usuarios.Dtos
{
    public class UsuarioDto
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
