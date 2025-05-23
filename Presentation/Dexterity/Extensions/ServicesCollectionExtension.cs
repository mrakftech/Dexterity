﻿using ClickATell.Extensions;
using DailyCo.Extensions;
using Dexterity.Adapters;
using ICDAPI;
using Services.Contracts.Repositroy;
using Services.Features.Admin.Interfaces;
using Services.Features.Admin.Service;
using Services.Features.Appointments.Service;
using Services.Features.Consultation.Service;
using Services.Features.Dashboard;
using Services.Features.Messaging.Service;
using Services.Features.PatientManagement.Service;
using Services.Features.Settings.Service;
using Services.Features.UserAccounts.Service;
using Services.Features.WaitingRoom.Service;
using Services.Respository;
using IMailService = Services.Features.Messaging.Mail.IMailService;
using MailService = Services.Features.Messaging.Mail.MailService;

namespace Dexterity.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IConsultationService, ConsultationService>();
        services.AddTransient<IWaitingRoomService, WaitingRoomService>();
        services.AddTransient<IAppointmentService, AppointmentService>();
        services.AddTransient<IPatientService, PatientService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ISettingService, SettingService>();
        services.AddTransient<IMessagingService, MessagingService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IMailService, MailService>();
        services.AddTransient<IFileManagerService, FileManagerService>();
        services.AddTransient<IDashboardService, DashboardService>();
        services.AddTransient<IFlagService, FlagService>();
        services.AddTransient<IAppService, AppService>();
        services.AddScoped<AppointmentDataAdaptor>();


        return services;
    }

    public static IServiceCollection AddExternalApis(this IServiceCollection services)
    {
        services.AddDailyCoApiServices();
        services.AddClickATellApiServices();
        services.AddIcdApi();

        return services;
    }
}