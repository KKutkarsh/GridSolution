using GridFunction.Core.Dtos;
using GridFunction.UnitTests.Factory;
using GridFunction.UnitTests.Utils;
using GridFunctions.ApiEndpoints;
using GridFunctions.Core.Entities;
using GridFunctions.Handlers.Interfaces;
using GridFunctions.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text;
using System.Text.Json;

namespace GridFunction.UnitTests.Tests.ApiEndpoints
{
    [TestClass]
    public class CollectedValueHttpGetFunctionTest
    {
        private List<Measure> fakeMeasureList = new();

        [TestInitialize]
        public void Setup()
        {
            fakeMeasureList = SerializationUtils.DeserializeFile<List<Measure>>(@"Measures.json");
        }

        [TestMethod]
        public async Task Run_ReturnsOkResult()
        {
            // Arrange
            Mock<ICollectedValueFunctionHandler> collectedValueFunctionHandlerMock = MockServicesFactory.GetMockedICollectedValueFunctionHandler(fakeMeasureList);
            Mock<ILogger<CollectedValueHttpGetFunction>> loggerMock = new();
            Mock<HttpRequest> httpRequestMock = new();

            CollectedValueHttpGetFunction function = new(
                collectedValueFunctionHandlerMock.Object,
                loggerMock.Object);

            NodeMeasurementQueryDto nodeMeasurementQueryDto = new()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            string jsonBody = JsonSerializer.Serialize(nodeMeasurementQueryDto);
            MemoryStream stream = new(Encoding.UTF8.GetBytes(jsonBody));
            httpRequestMock.Setup(req => req.Body).Returns(stream);

            // Act
            IActionResult result = await function.Run(httpRequestMock.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NativeJsonResult));

            NativeJsonResult okResult = (NativeJsonResult)result;
        }
    }
}
