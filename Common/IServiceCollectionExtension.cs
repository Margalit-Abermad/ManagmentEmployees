using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCommonLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapper.MappingProfile));

            return services;
        }
    }
}