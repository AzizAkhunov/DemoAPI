using Domain.Entities;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface ICompanyRepository
    {
        public Task CreateCompanyAsync(CreateCompanyDto company);
        public Task<Company> GetCompanyByIdAsync(Guid companyId);
        public Task<List<Company>> GetAllAsync();
        public Task<Company> DeleteCompanyByIdAsync(Guid companyId);
        public Task<Company> UpdateCompanyNameAsync(Guid companyId,string name);
    }
}
