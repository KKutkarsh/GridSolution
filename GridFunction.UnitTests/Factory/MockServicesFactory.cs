using GridFunction.Core.Dtos;
using GridFunctions.Core.Entities;
using GridFunctions.Handlers.Interfaces;
using GridFunctions.Services.Interfaces;
using Moq;

namespace GridFunction.UnitTests.Factory
{
    public static class MockServicesFactory
    {
        public static Mock<IMeasurementService> GetMockedIMeasurementService()
        {
            return new Mock<IMeasurementService>();
        }

        public static Mock<ICollectedValueFunctionHandler> GetMockedICollectedValueFunctionHandler(List<Measure> measures)
        {
            Mock<ICollectedValueFunctionHandler> mock = new();
            mock.Setup(handler => handler.HandleRequest(It.IsAny<NodeMeasurementQueryDto>()))
                                           .ReturnsAsync(measures);

            return mock;
        }

        public static Mock<ILatestValueFunctionHandler> GetMockedILatestValueFunctionHandler(List<Measure> measures)
        {
            Mock<ILatestValueFunctionHandler> mock = new();
            mock.Setup(handler => handler.HandleRequest(It.IsAny<NodeMeasurementQueryDto>()))
                                           .ReturnsAsync(measures);

            return mock;
        }
    }
}
