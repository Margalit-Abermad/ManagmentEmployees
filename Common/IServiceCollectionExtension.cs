using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCommonLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<Common.AutoMapper.MappingProfile>();
            });

            return services;
        }
    }
}