using System.ComponentModel.DataAnnotations.Schema;

namespace AdigunAndCoPayRollSystem.Models
{
    public class PayrollStructure
    {
        public int Id { get; set; }
        [ForeignKey("CadreLevelId")]
        public int CadreLevelId { get; set; }
        public CadreLevel CadreLevel { get; set; }
        [ForeignKey("PositionId")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<int> EarningComponentIds { get; set; }
        public List<int> DeductionComponentIds { get; set; }
    }
}
