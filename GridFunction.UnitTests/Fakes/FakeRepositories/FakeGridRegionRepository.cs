using GridFunction.Infrastructure;
using GridFunctions.Core.Entities;
using System.Linq.Expressions;

namespace GridFunction.UnitTests.Fakes.FakeRepositories
{
    public class FakeGridRegionRepository : IBaseRepository<GridRegion>
    {
        private readonly List<GridRegion> _regions = new();
        public FakeGridRegionRepository(List<GridRegion> gridRegions)
        {
            _regions.AddRange(gridRegions);
        }
        public int Commit()
        {
            throw new NotImplementedException();
        }

        public int Delete(GridRegion entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GridRegion> Get(Expression<Func<GridRegion, bool>> filter = null, Func<IQueryable<GridRegion>, IOrderedQueryable<GridRegion>> orderBy = null, string includeProperties = "")
        {
            return _regions.AsQueryable().Where(filter);
        }

        public GridRegion GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(GridRegion entity)
        {
            throw new NotImplementedException();
        }

        public int Update(GridRegion entity)
        {
            throw new NotImplementedException();
        }
    }
}
