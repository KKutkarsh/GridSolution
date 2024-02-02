namespace GridFunctions.Core.Entities
{
    public class GridRegion : BaseEntity
    {
        public string RegionName { get; set; }
        public int GridId { get; set; }
        public virtual Grid Grid { get; set; }

        public virtual ICollection<GridNode> GridNodes { get; set; }
    }
}
