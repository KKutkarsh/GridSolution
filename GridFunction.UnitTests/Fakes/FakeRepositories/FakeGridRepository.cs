using GridFunction.Infrastructure;
using GridFunctions.Core.Entities;
using System.Linq.Expressions;

namespace GridFunction.UnitTests.Fakes.FakeRepositories
{
    public class FakeGridRepository : IBaseRepository<Grid>
    {
        private readonly List<Grid> _grids = new();
        public FakeGridRepository(List<Grid> grids)
        {
            _grids.AddRange(grids);
        }
        public int Commit()
        {
            throw new NotImplementedException();
        }

        public int Delete(Grid entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Grid> Get(Expression<Func<Grid, bool>> filter = null, Func<IQueryable<Grid>, IOrderedQueryable<Grid>> orderBy = null, string includeProperties = "")
        {
            return _grids.AsQueryable().Where(filter);
        }

        public Grid GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Grid entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Grid entity)
        {
            throw new NotImplementedException();
        }
    }
}
