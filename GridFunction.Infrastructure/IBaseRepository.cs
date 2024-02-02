using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GridFunction.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Get(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    string includeProperties = "");

        T GetById(object id);
        void Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Commit();
    }
}
