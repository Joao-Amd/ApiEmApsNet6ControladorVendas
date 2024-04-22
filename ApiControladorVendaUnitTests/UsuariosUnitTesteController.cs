using ApiControladorVendas.Api.Controllers.Usuarios;
using ApiControladorVendas.Aplicacao.Usuarios;
using ApiControladorVendas.Aplicacao.Usuarios.Dtos;
using ApiControladorVendas.Dominio.Account;
using ApiControladorVendas.Repositorio.Contextos;
using ApiControladorVendas.Repositorio.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ApiControladorVendaUnitTests
{
    public class UsuariosUnitTesteController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAplicUsuario _aplicUsuario;
        private readonly IAuthenticate _authenticateService;


        public static DbContextOptions<Contexto> dbContextOptions { get;}

        public static string connectionString =
            "Server=localhost;Database=DbVendas;User Id=sa;Password=1234";

        static UsuariosUnitTesteController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Contexto>()
                 .UseSqlServer(connectionString)
                 .Options;
        }

        public UsuariosUnitTesteController(IAplicUsuario aplicUsuario, IAuthenticate authenticateService)
        {
            var context = new Contexto(dbContextOptions);

            _unitOfWork = new UnitOfWork(context);
            _aplicUsuario = aplicUsuario;
            _authenticateService = authenticateService;
        }

        [Fact]
        public void GetCategorias_Return_OkResult()
        {
            //Arrange
            var controller = new UsuarioController(_authenticateService, _aplicUsuario);

            //Act
            var data = controller.Get();

            Assert.IsType<List<UsuarioDto>>(data.Value);
        }
    }
}
