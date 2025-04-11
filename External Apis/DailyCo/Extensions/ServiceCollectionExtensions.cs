using System.Net.Http.Headers;
using DailyCo.Constants;
using DailyCo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DailyCo.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDailyCoApiServices(this IServiceCollection services)
    {
        services.AddHttpClient("dailyCoApi", (client) =>
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Base.ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
         services.AddTransient<RoomEnpoints>();
        return services;
    }
}