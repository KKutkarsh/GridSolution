namespace GridFunction.Core.Dtos
{
    public class NodeMeasurementQueryDto : DateQueryDto
    {
        public string NodeName { get; set; }
        public int NodeId { get; set; } = 0;
    }
}
