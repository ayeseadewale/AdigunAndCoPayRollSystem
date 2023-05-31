using AdigunAndCoPayRollSystem.Data;
using AdigunAndCoPayRollSystem.Models;
using AdigunAndCoPayRollSystem.Models.Dtos;
using System.Net;

namespace AdigunAndCoPayRollSystem.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDbContext _db;
        public EmployeeServices(ApplicationDbContext db)
        {
            _db = db;
        }
        //private static List<CadreLevel> cadreLevels = new List<CadreLevel>();
        //private static List<Position> positions = new List<Position>();
        //private static List<PayrollComponent> payrollComponents = new List<PayrollComponent>();
        //private static List<PayrollStructure> payrollStructures = new List<PayrollStructure>();
        //private static List<Employee> employees = new List<Employee>();
        

        public Employee AddEmployee(EmployeeRequestDto request)
        {
            var employee = new Employee
            {
                
                Name = request.Name,
                CadreLevelId = request.CadreLevelId,
                PositionId = request.PositionId
            };
            _db.Employee.Add(employee);
            _db.SaveChanges();
            return (employee);
        }

        public ResponseDto < PayrollComponentAssignmentRequestDto> AssignPayrollComponent(PayrollComponentAssignmentRequestDto assignment)
        {
            PayrollStructure payrollStructure = _db.PayrollStructure.FirstOrDefault(p =>
                p.CadreLevelId == assignment.CadreLevelId && p.PositionId == assignment.PositionId);
            if (payrollStructure == null)
                return ResponseDto<PayrollComponentAssignmentRequestDto>.Fail("Payroll Structure not found.", (int)HttpStatusCode.NotFound);

            if (assignment.Type == PayrollComponentType.Earnings)
            {
                payrollStructure.EarningComponentIds.Add(assignment.PayrollComponentId);

            }
            else if (assignment.Type == PayrollComponentType.Deductions)
            {
                payrollStructure.DeductionComponentIds.Add(assignment.PayrollComponentId);
            }
            else
            {
                return ResponseDto<PayrollComponentAssignmentRequestDto>.Fail("Invalid payroll component type.", (int)HttpStatusCode.BadRequest);
               
            }
            _db.PayrollStructure.Update(payrollStructure);
            _db.SaveChanges();
            return ResponseDto<PayrollComponentAssignmentRequestDto>.Success("Successful!", assignment,(int)HttpStatusCode.OK);
        }

        public CadreLevel CreateCadreLevel(CadreLevelRequestDto request)
        {
            var cadreLevel = new CadreLevel
            {
                
                Name = request.Name
            };
            _db.CadreLevel.Add(cadreLevel);
            _db.SaveChanges();
            return cadreLevel;
        }

        public PayrollComponent CreatePayrollComponent(PayrollComponentRequestDto request)
        {
            var payrollComponent = new PayrollComponent
            {
               
                Name = request.Name,
                Type = request.Type
            };
            _db.PayrollComponent.Add(payrollComponent);
            _db.SaveChanges();
            return payrollComponent;
        }

        public PayrollStructure CreatePayrollStructure(PayrollStructureRequestDto request)
        {
            var payRollStructure = new PayrollStructure
            {
                
                CadreLevelId = request.CadreLevelId,
                PositionId = request.PositionId,
                EarningComponentIds = request.EarningComponentIds,
                DeductionComponentIds = request.DeductionComponentIds

            };
            _db.PayrollStructure.Add(payRollStructure);
            _db.SaveChanges();
            return payRollStructure;
        }

        public Position CreatePosition(PositionRequestDto request)
        {
            var position = new Position
            {
               
                Name = request.Name,
                CadreLevelId = request.CadreLevelId
            };
            _db.Position.Add(position);
            _db.SaveChanges();
            return position;
        }

        public List<Employee> GetAllEmployees()
        {
            var AllEmployee = _db.Employee.ToList();
            return AllEmployee;
        }

        public List<PayrollComponent> GetEmployeePayroll(int employeeId)
        {
            var employee = _db.Employee.FirstOrDefault(emp => emp.Id == employeeId);
          

            var payrollStructure = _db.PayrollStructure.FirstOrDefault(p =>
                p.CadreLevelId == employee.CadreLevelId && p.PositionId == employee.PositionId);

            var payroll = new List<PayrollComponent>();
            payroll.AddRange(_db.PayrollComponent.Where(p => payrollStructure.EarningComponentIds.Contains(p.Id) &&
                                                          p.Type == PayrollComponentType.Earnings));
            payroll.AddRange(_db.PayrollComponent.Where(p => payrollStructure.DeductionComponentIds.Contains(p.Id) &&
                                                          p.Type == PayrollComponentType.Deductions));

            return payroll;
        }
        
        
    }
}
