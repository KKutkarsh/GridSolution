using GridFunctions.Services.Interfaces;

namespace GridFunction.UnitTests.Fakes.FakeRepositories
{
    public class EnvironmentHelperMock : IEnvironmentHelperService
    {
        //Need to mock response if further required
        public string GetEnvironmentVariable(string key)
        {
            return null;
        }
    }
}
