namespace AdigunAndCoPayRollSystem.Models
{
    public class CadreLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Employee Employee { get; set; }
        public PayrollStructure PayrollStructure { get; set; }
    }
}
