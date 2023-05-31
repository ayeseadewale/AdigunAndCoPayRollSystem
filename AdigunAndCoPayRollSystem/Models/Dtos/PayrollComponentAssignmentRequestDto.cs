using System.ComponentModel.DataAnnotations.Schema;

namespace AdigunAndCoPayRollSystem.Models.Dtos
{
    public class PayrollComponentAssignmentRequestDto
    {
        
        public int CadreLevelId { get; set; }
       
        public int PositionId { get; set; }
       
        public int PayrollComponentId { get; set; }
       
        public PayrollComponentType Type { get; set; }
    }
}
