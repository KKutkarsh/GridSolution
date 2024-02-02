namespace GridFunctions.Core.Entities
{
    public class Grid : BaseEntity
    {
        public string GridName { get; set; }
        public virtual ICollection<GridRegion> GridRegions { get; set; }
        public virtual ICollection<GridDetail> GridDetails { get; set; }
    }
}
