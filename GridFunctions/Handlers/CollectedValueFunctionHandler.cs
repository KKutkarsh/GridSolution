using GridFunction.Core.Dtos;
using GridFunctions.Core.Entities;
using GridFunctions.Handlers.Interfaces;
using GridFunctions.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridFunctions.Handlers
{
    public class CollectedValueFunctionHandler : ICollectedValueFunctionHandler
    {
        private readonly IMeasurementService _measurementService;
        public CollectedValueFunctionHandler(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }
        public async Task<List<Measure>> HandleRequest(NodeMeasurementQueryDto nodeMeasurementQueryDto)
        {
            if (nodeMeasurementQueryDto.NodeId > 0)
            {
                return await _measurementService.GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNodeId(nodeMeasurementQueryDto);
            }

            if (!string.IsNullOrWhiteSpace(nodeMeasurementQueryDto.NodeName))
            {
                return await _measurementService.GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNode(nodeMeasurementQueryDto);
            }

            return await _measurementService.GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRange(nodeMeasurementQueryDto);
        }
    }
}
