using EmployeesWebAPI.Requests.Employee;
using EmployeesWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            return Ok(await employeeService.GetEmployeeById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await employeeService.GetAllEmployees());
        }

        [HttpGet("company/{companyId:int}")]
        public async Task<IActionResult> GetEmployeesByCompanyId([FromRoute] int companyId)
        {
            return Ok(await employeeService.GetEmployeesByCompanyId(companyId));
        }

        [HttpGet("company/{companyId:int}/department/{departmentId:int}")]
        public async Task<IActionResult> GetEmployeesByCompanyIdAndDepartmentId([FromRoute] int companyId, [FromRoute] int departmentId)
        {
            return Ok(await employeeService.GetEmployeesByCompanyIdAndDepartmentId(companyId, departmentId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            return Ok(await employeeService.CreateEmployee(request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            await employeeService.DeleteEmployee(id);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            await employeeService.UpdateEmployee(request);

            return Ok(request.Id);
        }
    }
}
