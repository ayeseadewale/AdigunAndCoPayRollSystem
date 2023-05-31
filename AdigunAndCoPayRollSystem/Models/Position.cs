using System.ComponentModel.DataAnnotations.Schema;

namespace AdigunAndCoPayRollSystem.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("CadreLevelId")]
        public int CadreLevelId { get; set; }
        public CadreLevel CadreLevel { get; set; }
        
        public Employee Employee { get; set; }
        public PayrollStructure PayrollStructure { get; set; }

    }
}
