namespace WeaponsFactory.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IWeaponsFactoryDbContext context;

        public GenericRepository(IWeaponsFactoryDbContext weaponsFactoryContext)
        {
            this.context = weaponsFactoryContext;
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);

            return entity;
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
