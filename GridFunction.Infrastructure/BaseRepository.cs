using GridFunction.Infrastructure.DataContexts;
using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace GridFunction.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected GridContext gridContext;
        protected DbSet<T> dbSet;

        public BaseRepository(string connectionString)
        {
            gridContext = new GridContext(connectionString);
            gridContext.Database.EnsureCreated();
            dbSet = gridContext.Set<T>();
        }


        // For unit tests
        public BaseRepository(GridContext dbContext, DbSet<T> dbSet)
        {
            gridContext = dbContext;
            this.dbSet = dbSet;
        }


        public int Commit()
        {
            return gridContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            dbSet.Remove(entity);
            return Commit();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
            Commit();
        }

        public int Update(T entity)
        {
            if (gridContext.IsEntryDetached(entity))
            {
                dbSet.Attach(entity);
            }

            gridContext.SetState(entity, EntityState.Modified);
            return Commit();
        }
    }
}
