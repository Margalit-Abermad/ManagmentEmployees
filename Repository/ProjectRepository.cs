using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;

namespace Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly EmployeeDbContext context;

        public ProjectRepository(EmployeeDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await this.context.Projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await this.context.Projects.FirstOrDefaultAsync(p => p.Projectid == id);
        }

        public async Task<Project> CreateAsync(Project entity)
        {
            this.context.Projects.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<Project> UpdateAsync(Project entity)
        {
            this.context.Projects.Update(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await this.context.Projects.FirstOrDefaultAsync(p => p.Projectid == id);
            if (project == null) return false;

            this.context.Projects.Remove(project);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.context.Projects.AnyAsync(p => p.Projectid == id);
        }
    }
}