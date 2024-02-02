namespace GridFunctions.Core.Entities
{
    /// <summary>
    /// Separate table for TROs/TSOs because one grid can have multiple transmission lines
    /// being managed by different organisations.  
    /// </summary>
    public class GridDetail : BaseEntity
    {
        public string Name { get; set; }
        public string OtherDetails { get; set; }
        public int GridId { get; set; }
        public virtual Grid Grid { get; set; }
    }
}
