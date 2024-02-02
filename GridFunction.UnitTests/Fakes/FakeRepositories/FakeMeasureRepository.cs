using GridFunction.Infrastructure;
using GridFunctions.Core.Entities;
using System.Linq.Expressions;

namespace GridFunction.UnitTests.Fakes.FakeRepositories
{
    public class FakeMeasureRepository : IBaseRepository<Measure>
    {
        private readonly List<Measure> _measures = new();
        public FakeMeasureRepository(List<Measure> measures)
        {
            _measures.AddRange(measures);
        }
        public int Commit()
        {
            throw new NotImplementedException();
        }

        public int Delete(Measure entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Measure> Get(Expression<Func<Measure, bool>> filter = null, Func<IQueryable<Measure>, IOrderedQueryable<Measure>> orderBy = null, string includeProperties = "")
        {
            return _measures.AsQueryable().Where(filter);
        }

        public Measure GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Measure entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Measure entity)
        {
            throw new NotImplementedException();
        }
    }
}
