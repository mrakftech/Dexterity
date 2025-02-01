using Services.Features.Admin.Interfaces;
using Services.Features.Appointments.Service;
using Services.Features.Consultation.Service;
using Services.Features.Dashboard;
using Services.Features.Messaging.Service;
using Services.Features.PatientManagement.Service;
using Services.Features.Settings.Service;
using Services.Features.UserAccounts.Service;
using Services.Features.WaitingRoom.Service;

namespace Services.Contracts.Repositroy;

public interface IUnitOfWork: IDisposable
{
    IUserService User { get; }
    IPatientService Patient { get; }
    ISettingService Setting { get; }
    IMessagingService Messaging { get; }
    IAppointmentService Appointment { get; }
    IWaitingRoomService WaitingRoom { get; }
    IConsultationService Consultation { get; }
    IFileManagerService FileService { get; }
    IDashboardService Dashboard { get; }
    IFlagService Flag { get; }
}