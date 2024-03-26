using System.Linq.Expressions;

namespace ApiControladorVendas.Repositorio.RepCad
{
    public interface IRepCad<T>
    {
        T GetById(int id);
        List<T> Get();
        void Inserir(T t);
        void Delete(int id);
        bool Any();
        bool Any(Expression<Func<T, bool>> exp);
    }
}
