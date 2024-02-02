using GridFunction.Infrastructure;
using GridFunction.UnitTests.Fakes.FakeRepositories;
using GridFunctions.Core.Entities;
using GridFunctions.Services.Interfaces;

namespace GridFunction.UnitTests.Factory
{
    public static class MasterTestFactory
    {
        public static IEnvironmentHelperService GetEnvironmentHelperMock()
        {
            return new EnvironmentHelperMock();
        }

        public static IBaseRepository<Measure> GetFakeMeasurementRepository(List<Measure> measures)
        {
            return new FakeMeasureRepository(measures);
        }
    }
}
