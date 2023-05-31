namespace AdigunAndCoPayRollSystem.Models.Dtos
{
    public class PayrollStructureRequestDto
    {
        public int CadreLevelId { get; set; }
        public int PositionId { get; set; }
        public List<int> EarningComponentIds { get; set; }
        public List<int> DeductionComponentIds { get; set; }
    }
}
