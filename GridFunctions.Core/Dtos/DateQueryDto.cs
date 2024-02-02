namespace GridFunction.Core.Dtos
{
    /// <summary>
    /// It is suppose to get input paramenter for all datetime type requiement.
    /// Can be extended with other classe if more parameters are required.
    /// Pro: generic approach with reusability
    /// Cons: Will add extra unwanted parameter but very less in quantity
    /// </summary>
    public class DateQueryDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CollectedDate { get; set; }
    }
}
