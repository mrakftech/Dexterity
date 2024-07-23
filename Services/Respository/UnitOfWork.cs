using AutoMapper;
using Database;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.Repositroy;
using Services.Features.Messaging.Service;
using Services.Features.PatientManagement.Service;
using Services.Features.Settings.Service;
using Services.Features.UserAccounts.Service;

namespace Services.Respository;

public sealed class UnitOfWork(
    IUserService user,
    IPatientService patient,
    IMessagingService messaging,
    IMapper mapper,
    ISettingService setting,
    ApplicationDbContext context)
    : IUnitOfWork
{
    private bool _disposed;

    public IMessagingService Messaging
    {
        get
        {
            if (messaging == null)
            {
                 
                messaging = new MessagingService(context, mapper);
            }

            return messaging;
        }
    }

    public ISettingService Setting
    {
        get
        {
            if (setting == null)
            {
                

                setting = new SettingService(context, mapper);
            }

            return setting;
        }
    }

    public IUserService User
    {
        get
        {
            if (user == null)
            {
                

                user = new UserService(context, mapper);
            }

            return user;
        }
    }

    public IPatientService Patient
    {
        get
        {
            if (patient == null)
            {
                
                user = new UserService(context, mapper);
            }

            return patient;
        }
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}