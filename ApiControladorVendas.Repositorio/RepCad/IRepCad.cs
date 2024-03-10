using System.Linq.Expressions;

namespace ApiControladorVendas.Repositorio.RepCad
{
    public interface IRepCad<T>
    {
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        T GetById(int id);
        List<T> Get();
        T Single();
        T Single(Expression<Func<T, bool>> exp);
        T SingleOrDefault();
        T SingleOrDefault(Expression<Func<T, bool>> exp);
        T First();
        T First(Expression<Func<T, bool>> exp);
        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        IQueryable<TCampos> Select<TCampos>(Expression<Func<T, TCampos>> campos);
        IOrderedQueryable<T> OrderBy<TCampos>(Expression<Func<T, TCampos>> campos);
        IOrderedQueryable<T> OrderByDescending<TCampos>(Expression<Func<T, TCampos>> campos);
        void Inserir(T t);
        void Delete(int id);
        bool Any();
        bool Any(Expression<Func<T, bool>> exp);
    }
}
