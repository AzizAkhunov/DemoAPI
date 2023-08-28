using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Dtos;
using Service.Interfaces;

namespace Service.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto employee)
        {
            var employeecreate = new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                CompanyId = employee.companyId,
            };

            await dbContext.Employees.AddAsync(employeecreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var results = await dbContext.Employees.ToListAsync();

            return results;
        }

        public async Task<Employee> DeleteEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeId);
            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();

            }
            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeId);

            return employee;
        }

        public async Task<Employee> UpdateEmployeeNameAsync(Guid employeeId, string name)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeId);
            employee.FirstName = name;
            dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
