
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Repositorio.Contextos;

namespace ApiControladorVendaUnitTests
{
    public class DbUnitTestsMockInitializer
    {
        public DbUnitTestsMockInitializer(){}

        public void Seed(Contexto contexto)
        {
            contexto.Usuarios.Add
                (Usuario.Novo("teste", "teste@gmail.com"));
        }
    }
}
