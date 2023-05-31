using AdigunAndCoPayRollSystem.Models;
using AdigunAndCoPayRollSystem.Models.Dtos;

namespace AdigunAndCoPayRollSystem.Services
{
    public interface IEmployeeServices
    {
        Position CreatePosition(PositionRequestDto request);
        PayrollStructure CreatePayrollStructure(PayrollStructureRequestDto request);
        PayrollComponent CreatePayrollComponent(PayrollComponentRequestDto request);
        ResponseDto<PayrollComponentAssignmentRequestDto> AssignPayrollComponent(PayrollComponentAssignmentRequestDto assignment);
        CadreLevel CreateCadreLevel(CadreLevelRequestDto request);
        Employee AddEmployee(EmployeeRequestDto request);
        List<Employee> GetAllEmployees();
        List<PayrollComponent> GetEmployeePayroll(int employeeId);
    }
}
