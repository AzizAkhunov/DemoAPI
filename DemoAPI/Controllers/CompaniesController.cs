using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace DemoAPI.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyDto createCompanyDto)
        {
           await companyRepository.CreateCompanyAsync(createCompanyDto);

            return Ok("Created");
        }
        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCompanyId(Guid companyId)
        {
            var company = await companyRepository.GetCompanyByIdAsync(companyId);
            return Ok(company);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await companyRepository.GetAllAsync();

            return Ok(companies);
        }
        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(Guid companyId)
        {
            var companies = await companyRepository.DeleteCompanyByIdAsync(companyId);

            return Ok(companies);
        }
        [HttpPut("{companyId}")]
        public async Task<IActionResult> UpdateCompanyName(Guid companyId,string name)
        {
            var companies = await companyRepository.UpdateCompanyNameAsync(companyId,name);

            return Ok(companies);
        }
    }
}
