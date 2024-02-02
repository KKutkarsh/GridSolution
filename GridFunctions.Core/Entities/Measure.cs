namespace GridFunctions.Core.Entities
{
    public class Measure : BaseEntity
    {
        public DateTime CollectedAt { get; set; }
        public DateTime Timespan { get; set; }
        public int Measurement { get; set; }

        public int GridNodeId { get; set; }
        public virtual GridNode GridNode { get; set; }
    }
}
