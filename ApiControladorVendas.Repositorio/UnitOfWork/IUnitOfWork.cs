
namespace ApiControladorVendas.Repositorio.UnitOfWork
{
    public interface IUnitOfWork 
    {
        void Persistir();
        void RejectChanges();
    }
}
