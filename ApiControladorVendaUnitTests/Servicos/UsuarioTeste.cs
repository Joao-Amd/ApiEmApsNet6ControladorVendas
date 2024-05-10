using ApiControladorVendas.Aplicacao.Usuarios;
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Dominio.Usuarios.Dtos;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;
using Moq;
using Xunit;

namespace ApiControladorVenda.UnitTests.Servicos
{
    public class UsuarioTeste
    {
        private AplicUsuario _aplicUsuario;

        public UsuarioTeste()
        {
            _aplicUsuario = new AplicUsuario(new Mock<IRepCad<Usuario>>().Object, new Mock<IUnitOfWork>().Object);
        }

        [Fact]
        public void Post_Usuario_Senha_Null()
        {
            var usuarioDto = new UsuarioDto { Email = "joao@gmail.com", Nome = "João"};

            var teste = Assert.Throws<Exception>(() => _aplicUsuario.Inserir(usuarioDto));

        }
    }
}
