using Microsoft.EntityFrameworkCore;
using Moq;

namespace GridFunction.UnitTests.Utils
{
    public static class MockDbContext
    {
        public static Mock<DbSet<T>> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            dbSet.Setup(d => d.Remove(It.IsAny<T>())).Callback<T>((s) => sourceList.Remove(s));
            dbSet.Setup(d => d.RemoveRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>((s) =>
            {
                foreach (T element in s)
                {
                    sourceList.Remove(element);
                }
            });
            return dbSet;
        }
    }
}
