using AutoMapper;
using Database;
using Services.Contracts.Repositroy;
using Services.Features.Appointments.Service;
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
    IAppointmentService appointment,
    ApplicationDbContext context)
    : IUnitOfWork
{
    private bool _disposed;

    public IAppointmentService Appointment
    {
        get
        {
            if (appointment == null)
            {
                appointment = new AppointmentService(context, mapper);
            }

            return appointment;
        }
    }

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