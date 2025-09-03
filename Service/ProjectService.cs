using Repository;
using Repository.Models;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await projectRepository.GetAllAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await projectRepository.GetByIdAsync(id);
        }

        public async Task<Project> CreateAsync(Project entity)
        {
            return await projectRepository.CreateAsync(entity);
        }

        public async Task<Project> UpdateAsync(Project entity)
        {
            return await projectRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await projectRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await projectRepository.ExistsAsync(id);
        }
    }
}