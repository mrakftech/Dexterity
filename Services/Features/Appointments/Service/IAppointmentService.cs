using Domain.Entities.Appointments;
using Services.Features.Appointments.Dtos;
using Shared.Wrapper;

namespace Services.Features.Appointments.Service;

public interface IAppointmentService
{
    Task<List<SearchAppointmentDto>> FindAppointments();
    Task<List<AppointmentHistoryDto>> GetAppointmentHistory(Guid patientId);
    Task<List<AppointmentDto>> GetAllAppointments(DateTime startDate, DateTime endDate);
    Task<IResult<AppointmentDto>> GetAppointment(int id);
    Task<bool> IsSlotAvaiable(DateTime date, Guid hcpId);
    Task<List<AppointmentSlotDto>> GetFreeSlots(DateTime startDate, DateTime endDate, Guid hcpId);
    Task<IResult> SaveAppointment(int id, AppointmentDto appointment);
    Task<IResult> SaveAppointmentList( Appointment appointment);
    Task<IResult> CreateAppointment(AppointmentDto appointment);
    Task UpdateAppointment(AppointmentDto appointment);
    Task DeleteAppointment(int id);
    Task<IResult> CancelAppointment(int id, int cancelReasonId);
}