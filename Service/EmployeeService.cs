using Repository;
using Repository.Models;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await employeeRepository.GetByIdAsync(id);
        }

        public async Task<Employee> CreateAsync(Employee entity)
        {
            return await employeeRepository.CreateAsync(entity);
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            return await employeeRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await employeeRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await employeeRepository.ExistsAsync(id);
        }
    }
}