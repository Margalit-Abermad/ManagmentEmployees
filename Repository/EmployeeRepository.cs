using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await this.context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await this.context.Employees.FirstOrDefaultAsync(e => e.Employeeid == id);
        }

        public async Task<Employee> CreateAsync(Employee entity)
        {
            this.context.Employees.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            this.context.Employees.Update(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await this.context.Employees.FirstOrDefaultAsync(e => e.Employeeid == id);
            if (employee == null) return false;

            this.context.Employees.Remove(employee);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Employees.AnyAsync(e => e.Employeeid == id);
        }
    }
}