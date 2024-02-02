using GridFunction.Infrastructure;
using Moq;
using System.Linq.Expressions;

namespace GridFunction.UnitTests.Factory
{
    public static class MockRepositoriesFactory
    {
        public static Mock<IBaseRepository<T>> GetRepositoryMock<T>(ICollection<T> items) where T : class, new()
        {
            var mock = new Mock<IBaseRepository<T>>();
            mock.Setup(x => x
                .Get(
                    It.IsAny<Expression<Func<T, bool>>>(),
                    It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                    It.IsAny<string>()))
                .Returns(items.AsQueryable());
            mock.Setup(x => x.Commit()).Callback(() => { return; });
            return mock;
        }
    }
}
