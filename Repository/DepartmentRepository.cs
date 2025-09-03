using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;

namespace Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext context;

        public DepartmentRepository(EmployeeDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await this.context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await this.context.Departments.FirstOrDefaultAsync(d => d.Departmentid == id);
        }

        public async Task<Department> CreateAsync(Department entity)
        {
            this.context.Departments.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            this.context.Departments.Update(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await this.context.Departments.FirstOrDefaultAsync(d => d.Departmentid == id);
            if (department == null) return false;

            this.context.Departments.Remove(department);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Departments.AnyAsync(d => d.Departmentid == id);
        }
    }
}