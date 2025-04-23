using Microsoft.Extensions.DependencyInjection;

namespace ICDAPI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIcdApi(this IServiceCollection services)
    {
         services.AddTransient<HealthCodeService>();
        return services;
    }
}