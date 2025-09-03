using Repository;
using Repository.Models;

namespace Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await departmentRepository.GetAllAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await departmentRepository.GetByIdAsync(id);
        }

        public async Task<Department> CreateAsync(Department entity)
        {
            return await departmentRepository.CreateAsync(entity);
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            return await departmentRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await departmentRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await departmentRepository.ExistsAsync(id);
        }
    }
}