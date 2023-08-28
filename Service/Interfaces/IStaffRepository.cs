using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStaffRepository
    {

        public Task CreateStaffAsync(CreateStaffDto createStaff);
        public Task<Staff> GetStaffByIdAsync(Guid staffId);
        public Task DeleteStaffAsync(Guid staffId);
        public Task<List<Staff>> GetAllStaffsAsync();
        public Task<List<Employee>> GetAllEmployeesByStaffIdAsync(Guid staffId);
        public Task AddEmployeesToStaffAsync(Guid staffId,List<Guid> employeesId);
        public Task<Staff> UpdateStaffAsync(Guid staffId, string name);
    }
}
