using ApiControladorVendas.Repositorio.Contextos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiControladorVendas.Repositorio.RepCad
{
    public class RepCad<T> : IRepCad<T>, IDisposable where T : class
    {
        protected readonly DbContext Db;

        protected readonly DbSet<T> DbSet;

        public RepCad(Contexto contexto)
        {
            Db = contexto;
            DbSet = Db.Set<T>();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return DbSet.Where(exp);
        }

        public T Single()
        {
            return DbSet.Single();
        }

        public T Single(Expression<Func<T, bool>> exp)
        {
            return DbSet.Single(exp);
        }

        public T SingleOrDefault()
        {
            return DbSet.SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> exp)
        {
            return DbSet.SingleOrDefault(exp);
        }

        public T First()
        {
            return DbSet.First();
        }

        public T First(Expression<Func<T, bool>> exp)
        {
            return DbSet.First(exp);
        }

        public T FirstOrDefault()
        {
            return DbSet.FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return DbSet.FirstOrDefault(exp);
        }

        public IQueryable<TCampos> Select<TCampos>(Expression<Func<T, TCampos>> campos)
        {
            return DbSet.Select(campos);
        }

        public IOrderedQueryable<T> OrderBy<TCampos>(Expression<Func<T, TCampos>> campos)
        {
            return DbSet.OrderBy(campos);
        }

        public IOrderedQueryable<T> OrderByDescending<TCampos>(Expression<Func<T, TCampos>> campos)
        {
            return DbSet.OrderByDescending(campos);
        }

        public bool Any()
        {
            return DbSet.Any();
        }
        public void Inserir(T t)
        {
            DbSet.Add(t);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return DbSet.Any(exp);
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }
        public T GetById(int id)
        {
           return DbSet.Find(id);
        }

        public List<T> Get()
        {
            return DbSet.ToList();
        }
    }
}

