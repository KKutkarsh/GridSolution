using GridFunction.Core.Dtos;
using GridFunctions.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridFunctions.Handlers.Interfaces
{
    public interface IMeasureDataHandler
    {
        Task<List<Measure>> HandleRequest(NodeMeasurementQueryDto nodeMeasurementQueryDto);
    }
}
