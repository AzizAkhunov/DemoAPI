using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;
using Service.Services;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffRepository staffRepository;

        public StaffsController(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromForm] CreateStaffDto createStaff)
        {
            await staffRepository.CreateStaffAsync(createStaff);

            return Ok("created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await staffRepository.GetAllStaffsAsync());

        [HttpPost("staffId")]
        public async Task<IActionResult> AddEmployeesToStaff(Guid staffId,[FromForm]List<Guid> emloyeesId)
        {
            await staffRepository.AddEmployeesToStaffAsync(staffId, emloyeesId);

            return Ok("created");
        }
        [HttpPut("{StaffId}")]
        public async Task<IActionResult> UpdateStaffName(Guid staffId, string name)
        {
            var staffs = await staffRepository.UpdateStaffAsync(staffId, name);

            return Ok(staffs);
        }
    }
}
