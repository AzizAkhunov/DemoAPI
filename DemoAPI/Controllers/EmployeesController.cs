using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository companyRepository)
        {
            this.employeeRepository = companyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDto createEmployeeDto)
        {
            await employeeRepository.CreateEmployeeAsync(createEmployeeDto);

            return Ok("Created");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeId(Guid employeeId)
        {
            var company = await employeeRepository.GetEmployeeByIdAsync(employeeId);

            return Ok(company);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await employeeRepository.GetAllAsync();

            return Ok(employees);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var employees = await employeeRepository.DeleteEmployeeByIdAsync(employeeId);

            return Ok(employees);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeName(Guid employeeId, string name)
        {
            var employees = await employeeRepository.UpdateEmployeeNameAsync(employeeId, name);

            return Ok(employees);
        }
    }
}
