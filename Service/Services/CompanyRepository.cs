using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Dtos;
using Service.Interfaces;

namespace Service.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext dbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }
        public async Task CreateCompanyAsync(CreateCompanyDto company)
        {
            var companycreate = new Company()
            {
                Address = company.Address,
                Email = company.Email,
                Name = company.Name,
                Phone = company.Phone,
                Id = Guid.NewGuid()

            };

            await dbContext.Companies.AddAsync(companycreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            var results = await dbContext.Companies.ToListAsync();

            return results;
        }

        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await dbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);

            return company;
        }

        public async Task<Company> DeleteCompanyByIdAsync(Guid companyId)
        {
            var company = await dbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
            if (company is not null)
            {
                dbContext.Companies.Remove(company);
                dbContext.SaveChanges();
                
            }
            return company;
        }

        public async Task<Company> UpdateCompanyNameAsync(Guid companyId,string name)
        {
            var company = await dbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
            company.Name = name;
            await dbContext.SaveChangesAsync();
            return company;
        }
    }
}
