using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;

namespace Repository
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly EmployeeDbContext context;

        public EmployeeProjectRepository(EmployeeDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employeeproject>> GetAllAsync()
        {
            return await this.context.Employeeprojects.ToListAsync();
        }

        public async Task<Employeeproject?> GetByIdAsync(int id)
        {
            return await this.context.Employeeprojects.FirstOrDefaultAsync(ep => ep.Employeeid == id);
        }

        public async Task<Employeeproject> CreateAsync(Employeeproject entity)
        {
            this.context.Employeeprojects.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employeeproject> UpdateAsync(Employeeproject entity)
        {
            this.context.Employeeprojects.Update(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employeeProject = await this.context.Employeeprojects.FirstOrDefaultAsync(ep => ep.Employeeid == id);
            if (employeeProject == null) return false;

            this.context.Employeeprojects.Remove(employeeProject);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Employeeprojects.AnyAsync(ep => ep.Employeeid == id);
        }
    }
}