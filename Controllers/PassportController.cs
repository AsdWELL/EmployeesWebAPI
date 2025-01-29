using EmployeesWebAPI.Requests.Passport;
using EmployeesWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PassportController(IPassportService passportService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPassportById([FromRoute] int id)
        {
            return Ok(await passportService.GetPassportById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassports()
        {
            return Ok(await passportService.GetAllPassports());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePassport([FromBody] CreatePassportRequest request)
        {
            return Ok(await passportService.CreatePassport(request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePassport([FromRoute] int id)
        {
            await passportService.DeletePassport(id);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePassport([FromBody] UpdatePassportRequest request)
        {
            await passportService.UpdatePassport(request);

            return Ok(request.Id);
        }
    }
}
