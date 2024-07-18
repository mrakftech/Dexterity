using ClickATell.Extensions;
using DailyCo.Extensions;
using MailKit;
using Services.Contracts.Repositroy;
using Services.Features.Messaging;
using Services.Features.Messaging.SmsTemplate;
using Services.Features.PatientManagement.Service;
using Services.Features.UserAccounts.Service;
using Services.Respository;
using IMailService = Services.Features.Messaging.Mail.IMailService;
using MailService = Services.Features.Messaging.Mail.MailService;

namespace Dexterity.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISmsTemplateRepository, SmsTemplateRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IMailService, MailService>();

        return services;
    }
    
    public static IServiceCollection AddExternalApis(this IServiceCollection services)
    {
        services.AddDailyCoApiServices();
        services.AddClickATellApiServices();

        return services;
    }
}