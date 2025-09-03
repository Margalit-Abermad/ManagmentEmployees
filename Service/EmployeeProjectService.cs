using Repository;
using Repository.Models;

namespace Service
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly IEmployeeProjectRepository employeeProjectRepository;

        public EmployeeProjectService(IEmployeeProjectRepository employeeProjectRepository)
        {
            this.employeeProjectRepository = employeeProjectRepository;
        }

        public async Task<IEnumerable<Employeeproject>> GetAllAsync()
        {
            return await employeeProjectRepository.GetAllAsync();
        }

        public async Task<Employeeproject?> GetByIdAsync(int id)
        {
            return await employeeProjectRepository.GetByIdAsync(id);
        }

        public async Task<Employeeproject> CreateAsync(Employeeproject entity)
        {
            return await employeeProjectRepository.CreateAsync(entity);
        }

        public async Task<Employeeproject> UpdateAsync(Employeeproject entity)
        {
            return await employeeProjectRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await employeeProjectRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await employeeProjectRepository.ExistsAsync(id);
        }
    }
}