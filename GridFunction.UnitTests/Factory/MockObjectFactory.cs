using GridFunction.UnitTests.Utils;
using GridFunctions.Core.Entities;

namespace GridFunction.UnitTests.Factory
{
    public class MockObjectFactory
    {
        public static List<Measure>  GetFakeMeasurementList()
        {
            List<Measure> measures = SerializationUtils.DeserializeFile<List<Measure>>(@"Measures.json").ToList();
            return measures;

        }
    }
}
