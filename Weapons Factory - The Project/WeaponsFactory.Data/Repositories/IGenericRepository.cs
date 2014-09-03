namespace WeaponsFactory.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Search(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        T Delete(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
