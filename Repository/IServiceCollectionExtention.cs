using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Data;

namespace Repository
{
    public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IEmployeeProjectRepository, EmployeeProjectRepository>();

            return services;
        }
    }
}
