using GridFunction.Core.Dtos;
using GridFunction.UnitTests.Factory;
using GridFunctions.Handlers;
using GridFunctions.Services.Interfaces;
using Moq;

namespace GridFunction.UnitTests.Tests.Handlers
{
    [TestClass]
    public class LatestValueFunctionHandlerTest
    {
        [TestMethod]
        public async Task HandleRequest_WithNodeId_CallsGetLatestMeasurementPerTimeStampForGivenDateRangeAndNodeId()
        {
            // Arrange
            Mock<IMeasurementService> measurementServiceMock = MockServicesFactory.GetMockedIMeasurementService();
            LatestValueFunctionHandler handler = new(measurementServiceMock.Object);

            NodeMeasurementQueryDto nodeMeasurementQueryDto = new() {
                NodeId = 1,
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow
            };

            // Act
            await handler.HandleRequest(nodeMeasurementQueryDto);

            // Assert
            measurementServiceMock.Verify(
                x => x.GetLatestMeasurementPerTimeStampForGivenDateRangeAndNodeId(It.IsAny<NodeMeasurementQueryDto>()),
                Times.Once);
        }

        [TestMethod]
        public async Task HandleRequest_WithNodeName_CallsGetLatestMeasurementPerTimeStampForGivenDateRangeAndNode()
        {
            // Arrange
            Mock<IMeasurementService> measurementServiceMock = MockServicesFactory.GetMockedIMeasurementService();
            LatestValueFunctionHandler handler = new(measurementServiceMock.Object);

            NodeMeasurementQueryDto nodeMeasurementQueryDto = new()
            {
                NodeName = "TestName",
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow
            };

            // Act
            await handler.HandleRequest(nodeMeasurementQueryDto);

            // Assert
            measurementServiceMock.Verify(
                x => x.GetLatestMeasurementPerTimeStampForGivenDateRangeAndNode(It.IsAny<NodeMeasurementQueryDto>()),
                Times.Once);
        }

        [TestMethod]
        public async Task HandleRequest_WithoutNodeIdOrNodeNameAndWithDateRange_CallsGetLatestMeasurementPerTimeStampForGivenDateRange()
        {
            // Arrange
            Mock<IMeasurementService> measurementServiceMock = MockServicesFactory.GetMockedIMeasurementService();
            LatestValueFunctionHandler handler = new(measurementServiceMock.Object);

            NodeMeasurementQueryDto nodeMeasurementQueryDto = new()
            {
                EndDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow
            };

            // Act
            await handler.HandleRequest(nodeMeasurementQueryDto);

            // Assert
            measurementServiceMock.Verify(
                x => x.GetLatestMeasurementPerTimeStampForGivenDateRange(It.IsAny<NodeMeasurementQueryDto>()),
                Times.Once);
        }
    }
}
