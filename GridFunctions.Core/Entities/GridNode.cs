namespace GridFunctions.Core.Entities
{
    public class GridNode : BaseEntity
    {
        public string NodeName { get; set; }
        public int GridRegionId { get; set; }
        public virtual GridRegion Region { get; set; }

        public virtual ICollection<Measure> Measures { get; set; }
    }
}
