using AutoMapper;
using ClickATell.Services;
using Database;
using Services.Contracts.Repositroy;
using Services.Features.Appointments.Service;
using Services.Features.Consultation.Service;
using Services.Features.Dashboard;
using Services.Features.Messaging.Mail;
using Services.Features.Messaging.Service;
using Services.Features.PatientManagement.Service;
using Services.Features.Settings.Service;
using Services.Features.UserAccounts.Service;
using Services.Features.WaitingRoom.Service;

namespace Services.Respository;

public sealed class UnitOfWork(
    IUserService user,
    IPatientService patient,
    IMessagingService messaging,
    IMapper mapper,
    ISettingService setting,
    IAppointmentService appointment,
    IConsultationService consultation,
    IDashboardService dashboard,
    IWaitingRoomService waitingRoom,
    IFileManagerService fileManager,
    IMailService mail,
    SmsEndpoints smsEndpoints,
    ApplicationDbContext context)
    : IUnitOfWork
{
    private bool _disposed;
    public IDashboardService Dashboard   
    {
        get
        {
            if (dashboard == null)
            {
                dashboard = new DashboardService(context);
            }

            return dashboard;
        }
    }

    public IConsultationService Consultation
    {
        get
        {
            if (consultation == null)
            {
                consultation = new ConsultationService(context, mapper, patient, setting, fileManager, mail);
            }

            return consultation;
        }
    }

    public IWaitingRoomService WaitingRoom
    {
        get
        {
            if (waitingRoom == null)
            {
                waitingRoom = new WaitingRoomService(context, mapper);
            }

            return waitingRoom;
        }
    }

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
                messaging = new MessagingService(context, mapper, smsEndpoints);
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

    public IFileManagerService FileService
    {
        get
        {
            if (fileManager == null)
            {
                fileManager = new FileManagerService();
            }

            return fileManager;
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