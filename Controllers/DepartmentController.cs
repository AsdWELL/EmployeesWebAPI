using EmployeesWebAPI.Requests.Department;
using EmployeesWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController(IDepartmentService departmentService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            return Ok(await departmentService.GetDepartmentById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await departmentService.GetAllDepartments());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
        {
            return Ok(await departmentService.CreateDepartment(request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            await departmentService.DeleteDepartment(id);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest request)
        {
            await departmentService.UpdateDepartment(request);

            return Ok(request.Id);
        }
    }
}
