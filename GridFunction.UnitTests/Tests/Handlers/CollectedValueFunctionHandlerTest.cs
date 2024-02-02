using GridFunction.Core.Dtos;
using GridFunction.UnitTests.Factory;
using GridFunctions.Handlers;
using GridFunctions.Services.Interfaces;
using Moq;

namespace GridFunction.UnitTests.Tests.Handlers
{
    [TestClass]
    public class CollectedValueFunctionHandlerTest
    {
        [TestMethod]
        public async Task HandleRequest_WithNodeId_CallsGetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNodeId()
        {
            // Arrange
            Mock<IMeasurementService> measurementServiceMock = MockServicesFactory.GetMockedIMeasurementService();
            CollectedValueFunctionHandler handler = new(measurementServiceMock.Object);

            NodeMeasurementQueryDto nodeMeasurementQueryDto = new()
            {
                StartDate = DateTime.Now,
                NodeId = 1,
                EndDate = DateTime.Now
            };

            // Act
            await handler.HandleRequest(nodeMeasurementQueryDto);

            // Assert
            measurementServiceMock.Verify(
                service => service.GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNodeId(It.IsAny<NodeMeasurementQueryDto>()),
                Times.Once);
        }

        [TestMethod]
        public async Task HandleRequest_WithNodeName_CallsGetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNode()
        {
            // Arrange
            Mock<IMeasurementService> measurementServiceMock = MockServicesFactory.GetMockedIMeasurementService();
            CollectedValueFunctionHandler handler = new(measurementServiceMock.Object);

            NodeMeasurementQueryDto nodeMeasurementQueryDto = new()
            {
                NodeName = "AnyNode",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            // Act
            await handler.HandleRequest(nodeMeasurementQueryDto);

            // Assert
            measurementServiceMock.Verify(
                service => service.GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNode(It.IsAny<NodeMeasurementQueryDto>()),
                Times.Once);
        }

        [TestMethod]
        public async Task HandleRequest_WithoutNodeIdOrNodeNameAndWithDateRange_CallsGetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRange()
        {
            // Arrange
            Mock<IMeasurementService> measurementServiceMock = new();
            CollectedValueFunctionHandler handler = new(measurementServiceMock.Object);

            NodeMeasurementQueryDto queryDto = new()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            // Act
            await handler.HandleRequest(queryDto);

            // Assert
            measurementServiceMock.Verify(
                service => service.GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRange(It.IsAny<NodeMeasurementQueryDto>()),
                Times.Once);
        }
    }
}
