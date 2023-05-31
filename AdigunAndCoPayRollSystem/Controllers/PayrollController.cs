using AdigunAndCoPayRollSystem.Data;
using AdigunAndCoPayRollSystem.Models;
using AdigunAndCoPayRollSystem.Models.Dtos;
using AdigunAndCoPayRollSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdigunAndCoPayRollSystem.Controllers
{

    [ApiController]
    [Route("api/payroll")]
    public class PayrollController : ControllerBase
    {

        private readonly IEmployeeServices _employees;
        public PayrollController(IEmployeeServices Employee)
        {
            _employees = Employee;
        }

        
        //Create Cadrelevels
        [HttpPost("create-cadrelevels")]
        public ActionResult<CadreLevel> CreateCadreLevel(CadreLevelRequestDto request)
        {
            
            return Ok(_employees.CreateCadreLevel(request));
        }

        // Endpoint to create a new position
        [HttpPost("create-positions")]
        public ActionResult<Position> CreatePosition(PositionRequestDto request)
        {

            return Ok(_employees.CreatePosition(request));
        }
        
        // Endpoint to create a payroll structure for each employee cadre level and position
        [HttpPost("create-payroll-structures")]
        public ActionResult<PayrollStructure> CreatePayrollStructure(PayrollStructureRequestDto request)
        {

            return Ok(_employees.CreatePayrollStructure(request));
        }

        // Endpoint to create components of the payroll system (Earnings and Deductions)
        [HttpPost("create-payroll-components")]
        public ActionResult<PayrollComponent> CreatePayrollComponent(PayrollComponentRequestDto request)
        {

            return Ok(_employees.CreatePayrollComponent(request));
        }

        // Endpoint to assign each payroll component for each cadre level and position
        [HttpPost("assign-payroll-component")]
        public ActionResult AssignPayrollComponent(PayrollComponentAssignmentRequestDto assignment)
        {
            var response = _employees.AssignPayrollComponent(assignment);
            return StatusCode(response.StatusCode,response);
        }

        //Add Employees
        [HttpPost("add-employees")]
        public ActionResult<Employee> AddEmployee(EmployeeRequestDto request)
        {
            
            return Ok(_employees.AddEmployee(request));
        }

        //Endpoint to allow staffs to view all employees
        [HttpGet("get-all-employees")]
        public ActionResult<List<Employee>> GetAllEmployees()
        {

            return Ok(_employees.GetAllEmployees());  
        }
        
        // Endpoint to allow staffs to view all their earnings and deductions
        [HttpGet("get-employees-payroll/{employeeId}")]
        public ActionResult<List<PayrollComponent>> GetEmployeePayroll(int employeeId)
        {

            return Ok(_employees.GetEmployeePayroll(employeeId));
        }
    }
}