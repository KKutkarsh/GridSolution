using GridFunction.Infrastructure;
using GridFunctions.Core.Entities;
using System.Linq.Expressions;

namespace GridFunction.UnitTests.Fakes.FakeRepositories
{
    internal class FakeGridNodeRepository : IBaseRepository<GridNode>
    {
        private readonly List<GridNode> _gridNodes = new();
        public FakeGridNodeRepository(List<GridNode> gridNodes)
        {
            _gridNodes.AddRange(gridNodes);
        }
        public int Commit()
        {
            throw new NotImplementedException();
        }

        public int Delete(GridNode entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GridNode> Get(Expression<Func<GridNode, bool>> filter = null, Func<IQueryable<GridNode>, IOrderedQueryable<GridNode>> orderBy = null, string includeProperties = "")
        {
            return _gridNodes.AsQueryable().Where(filter);
        }

        public GridNode GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(GridNode entity)
        {
            throw new NotImplementedException();
        }

        public int Update(GridNode entity)
        {
            throw new NotImplementedException();
        }
    }
}
