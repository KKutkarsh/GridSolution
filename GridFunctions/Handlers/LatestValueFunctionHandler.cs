using GridFunction.Core.Dtos;
using GridFunctions.Core.Entities;
using GridFunctions.Handlers.Interfaces;
using GridFunctions.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridFunctions.Handlers
{
    /// <summary>
    /// It is suppose to be handling and taking all required decisions for the calls coming to `LatestValueHttpGetFunction` 
    /// </summary>
    public class LatestValueFunctionHandler : ILatestValueFunctionHandler
    {
        private readonly IMeasurementService _measurementService;
        public LatestValueFunctionHandler(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        // Method can be optimized using strategy pattern but that will be over engineering for small business requirement
        public async Task<List<Measure>> HandleRequest(NodeMeasurementQueryDto nodeMeasurementQueryDto)
        {
            if(nodeMeasurementQueryDto.NodeId > 0)
            {
                return await _measurementService.GetLatestMeasurementPerTimeStampForGivenDateRangeAndNodeId(nodeMeasurementQueryDto);
            }

            if (!string.IsNullOrWhiteSpace(nodeMeasurementQueryDto.NodeName))
            {
                return await _measurementService.GetLatestMeasurementPerTimeStampForGivenDateRangeAndNode(nodeMeasurementQueryDto);
            }
            
            return await _measurementService.GetLatestMeasurementPerTimeStampForGivenDateRange(nodeMeasurementQueryDto);
        }
    }
}
