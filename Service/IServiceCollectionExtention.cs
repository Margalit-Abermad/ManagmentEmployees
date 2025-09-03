using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();

            return services;
        }
    }
}
