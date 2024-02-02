using GridFunction.Infrastructure;
using GridFunction.Infrastructure.DataContexts;
using GridFunction.UnitTests.Utils;
using GridFunctions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GridFunction.UnitTests.Tests.Repository
{
    [TestClass]
    [TestCategory("Data Repositories")]
    public class BaseRepositoryTest
    {
        private Mock<GridContext> domainMock;
        private BaseRepository<Grid> repository;
        private static readonly List<Grid> fakeData = new();

        [TestInitialize()]
        public void Setup()
        {
            fakeData.Clear();
            fakeData.Add(new Grid() { Id = 1, GridName = "Grid1" });
            fakeData.Add(new Grid() { Id = 2, GridName = "Grid1" });
            fakeData.Add(new Grid() { Id = 3, GridName = "Grid1" });

            domainMock = new Mock<GridContext>();

            var dbSetMock = MockDbContext.GetQueryableMockDbSet<Grid>(fakeData);
            dbSetMock.Setup(d => d.Find(It.IsAny<object[]>())).Returns<object[]>((s) => fakeData.Find(x => s.Contains(x.Id)));
            repository = new BaseRepository<Grid>(domainMock.Object, dbSetMock.Object);
        }

        [TestMethod]
        public void Should_get_list_of_entities()
        {
            // Arrange
            var result = repository.Get();

            // Act
            var objectUnderTest = result.All(x => fakeData.Contains(x));

            // Assert
            Assert.IsTrue(objectUnderTest, "should get entity list");
        }

        [TestMethod]
        public void Should_get_an_item()
        {
            // Arrange
            var fakeItem = fakeData[0];

            // Act
            var objectUnderTest = repository.GetById(fakeItem.Id);

            // Assert
            Assert.AreEqual(objectUnderTest, fakeItem, "should get one item by id");
        }

        [TestMethod]
        public void Should_return_null_when_getting_a_inexistent_item()
        {
            // Arrange
            var fakeID = 52;

            // Act
            var objectUnderTest = repository.GetById(fakeID);

            // Assert
            Assert.IsNull(objectUnderTest);
        }
    }
}
