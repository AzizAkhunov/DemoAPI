using Domain.Entities;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task CreateEmployeeAsync(CreateEmployeeDto employee);
        public Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> DeleteEmployeeByIdAsync(Guid companyId);
        public Task<Employee> UpdateEmployeeNameAsync(Guid companyId, string name);
    }
}
