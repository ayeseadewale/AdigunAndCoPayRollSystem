using System.ComponentModel.DataAnnotations.Schema;

namespace AdigunAndCoPayRollSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("CadreLevelId")]
        public int CadreLevelId { get; set; }
        public CadreLevel CadreLevel { get; set; }
        [ForeignKey("PositionId")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
