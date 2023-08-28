using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Dtos;
using Service.Interfaces;
using System.ComponentModel.Design;

namespace Service.Services
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext dbContext;

        public StaffRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public async Task AddEmployeesToStaffAsync(Guid staffId, List<Guid> employeeIds)
        {
            var staff = await dbContext.Staffs.FirstOrDefaultAsync(s => s.Id == staffId);

            if (staff is not null)
            {
                foreach (var i in employeeIds)
                {
                    var employee = await dbContext.Employees.
                        FirstOrDefaultAsync(e => e.Id == i);

                    staff.Employees.Add(employee);
                    await dbContext.SaveChangesAsync();

                }
            }
        }

        public async Task CreateStaffAsync(CreateStaffDto createStaff)
        {
            var staff = new Staff
            {
                Id = Guid.NewGuid(),
                Name = createStaff.Name,
            };

            await dbContext.Staffs.AddAsync(staff);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteStaffAsync(Guid staffId)
        {
            var staff = await dbContext.Staffs.FirstOrDefaultAsync(s => s.Id == staffId);
            if (staff is not null)
            {
                dbContext.Staffs.Remove(staff);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetAllEmployeesByStaffIdAsync(Guid staffId)
        {
            var staff = await dbContext.Staffs.Include(e => e.Employees)
                .FirstOrDefaultAsync(s => s.Id == staffId);

            return staff.Employees.ToList();
        }

        public async Task<List<Staff>> GetAllStaffsAsync() =>
            await dbContext.Staffs.Include(e => e.Employees).ToListAsync();


        public async Task<Staff> GetStaffByIdAsync(Guid staffId) =>
            await dbContext.Staffs.FirstOrDefaultAsync(s => s.Id == staffId);


        public async Task<Staff> UpdateStaffAsync(Guid staffId, string name)
        {
            var staff = await dbContext.Staffs.FirstOrDefaultAsync(c => c.Id == staffId);
            staff.Name = name;
            dbContext.SaveChangesAsync();
            return staff;
        }
    }
}