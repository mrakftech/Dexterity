using System.Net.Http.Headers;
using ClickATell.Constants;
using ClickATell.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClickATell.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClickATellApiServices(this IServiceCollection services)
    {
        services.AddHttpClient("clickATellApi", (client) =>
        {
            //client.DefaultRequestHeaders.Add("ApiKey", Base.ApiKey);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Base.ApiKey);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", Base.ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
         services.AddTransient<SmsEndpoints>();
        return services;
    }
}