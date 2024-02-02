using GridFunction.Core.Dtos;
using GridFunctions.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridFunctions.Services.Interfaces
{
    /// <summary>
    /// This service is responsible to taking decision on all the calls related to Grid Node measurementData
    /// </summary>
    public interface IMeasurementService
    {
        // timestamp based
        Task<List<Measure>> GetLatestMeasurementPerTimeStampForGivenDateRange(NodeMeasurementQueryDto dateRange);
        Task<List<Measure>> GetLatestMeasurementPerTimeStampForGivenDateRangeAndNode(NodeMeasurementQueryDto nodeMeasurementQueryDto);
        Task<List<Measure>> GetLatestMeasurementPerTimeStampForGivenDateRangeAndNodeId(NodeMeasurementQueryDto nodeMeasurementQueryDto);

        //collected date based
        Task<List<Measure>> GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRange(NodeMeasurementQueryDto nodeMeasurementQueryDto);
        Task<List<Measure>> GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNode(NodeMeasurementQueryDto nodeMeasurementQueryDto);
        Task<List<Measure>> GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNodeId(NodeMeasurementQueryDto nodeMeasurementQueryDto);
    }
}
