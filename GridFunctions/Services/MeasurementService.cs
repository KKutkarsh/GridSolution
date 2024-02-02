using GridFunction.Core.Dtos;
using GridFunction.Infrastructure;
using GridFunctions.Core.Entities;
using GridFunctions.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridFunctions.Services
{
    /// <summary>
    /// This service is responsible to taking decision on all the calls related to Grid Node measurementData
    /// 
    /// currently the methods return whole data. We can use flattend DTO to retun data in required format.
    /// </summary>
    public class MeasurementService : IMeasurementService
    {
        private readonly IBaseRepository<Measure> _measureRepository;
        public MeasurementService(IBaseRepository<Measure> measureRepository)
        {
            _measureRepository = measureRepository;
        }
        public async Task<List<Measure>> GetLatestMeasurementPerTimeStampForGivenDateRangeAndNode(NodeMeasurementQueryDto nodeMeasurementQueryDto)
        {
            List<Measure> measurementList = await _measureRepository
                .Get(x => x.Timespan >= nodeMeasurementQueryDto.StartDate &&
                            x.Timespan <= nodeMeasurementQueryDto.EndDate &&
                            x.GridNode.NodeName.ToLower().Equals(nodeMeasurementQueryDto.NodeName.Trim().ToLower())
                    )
                    .Include(x => x.GridNode)
                    .ThenInclude(x => x.Region)
                    .ThenInclude(x => x.Grid)
                    .GroupBy(x => x.Timespan)
                    .Select(x => x.OrderByDescending(t => t.CollectedAt).FirstOrDefault())
                    .ToListAsync();

            return measurementList;
        }

        public async Task<List<Measure>> GetLatestMeasurementPerTimeStampForGivenDateRangeAndNodeId(NodeMeasurementQueryDto nodeMeasurementQueryDto)
        {
            List<Measure> measurementList = await _measureRepository
                .Get(x => x.Timespan >= nodeMeasurementQueryDto.StartDate &&
                            x.Timespan <= nodeMeasurementQueryDto.EndDate &&
                            x.GridNodeId == nodeMeasurementQueryDto.NodeId
                    )
                    .Include(x => x.GridNode)
                    .ThenInclude(x => x.Region)
                    .ThenInclude(x => x.Grid)
                    .GroupBy(x => x.Timespan)
                    .Select(x => x.OrderByDescending(t => t.CollectedAt).FirstOrDefault())
                    .ToListAsync();

            return measurementList;
        }

        public async Task<List<Measure>> GetLatestMeasurementPerTimeStampForGivenDateRange(NodeMeasurementQueryDto dateRange)
        {
            List<Measure> measurementList = await _measureRepository
                .Get(x => x.Timespan >= dateRange.StartDate && x.Timespan <= dateRange.EndDate)
                    .Include(x => x.GridNode)
                    .ThenInclude(x => x.Region)
                    .ThenInclude(x => x.Grid).GroupBy(x => x.Timespan)
                    .Select(x => x.OrderByDescending(t => t.CollectedAt).FirstOrDefault())
                    .ToListAsync();

            return measurementList;
        }

        public async Task<List<Measure>> GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRange(NodeMeasurementQueryDto nodeMeasurementQueryDto)
        {
            List<Measure> measurementList = await _measureRepository
                .Get(x =>
                        //select data with timestamp the given range
                        x.Timespan >= nodeMeasurementQueryDto.StartDate &&
                        x.Timespan <= nodeMeasurementQueryDto.EndDate &&

                        //selects timestap values from selected ones whose collectedAt at corresponds to input collected datetime 
                        x.CollectedAt == nodeMeasurementQueryDto.CollectedDate
                    )
                    .Include(x => x.GridNode)
                    .ThenInclude(x => x.Region)
                    .ThenInclude(x => x.Grid)
                    .ToListAsync();

            return measurementList;
        }

        public async Task<List<Measure>> GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNode(NodeMeasurementQueryDto nodeMeasurementQueryDto)
        {
            List<Measure> measurementList = await _measureRepository
                .Get(x => //select data with timestamp the given range
                        x.Timespan >= nodeMeasurementQueryDto.StartDate &&
                        x.Timespan <= nodeMeasurementQueryDto.EndDate &&

                        //selects timestap values from selected ones whose collectedAt at corresponds to input collected datetime 
                        x.CollectedAt == nodeMeasurementQueryDto.CollectedDate &&
                        x.GridNode.NodeName.ToLower().Equals(nodeMeasurementQueryDto.NodeName.Trim().ToLower())
                    )
                    .Include(x => x.GridNode)
                    .ThenInclude(x => x.Region)
                    .ThenInclude(x => x.Grid)
                    .ToListAsync();

            return measurementList;
        }

        public async Task<List<Measure>> GetLatestMeasurementCorrespondingToCollectedTimeStampForGivenDateRangeAndNodeId(NodeMeasurementQueryDto nodeMeasurementQueryDto)
        {
            List<Measure> measurementList = await _measureRepository
                .Get(x => x.Timespan >= nodeMeasurementQueryDto.StartDate &&
                            x.Timespan <= nodeMeasurementQueryDto.EndDate &&
                            x.GridNodeId == nodeMeasurementQueryDto.NodeId &&
                            x.CollectedAt == nodeMeasurementQueryDto.CollectedDate
                    )
                    .Include(x => x.GridNode)
                    .ThenInclude(x => x.Region)
                    .ThenInclude(x => x.Grid)
                    .GroupBy(x => x.Timespan)
                    .Select(x => x.FirstOrDefault())
                    .ToListAsync();

            return measurementList;
        }
    }
}
