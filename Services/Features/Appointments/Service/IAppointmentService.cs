using Services.Features.Appointments.Dtos;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.Appointments.Service;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAllAppointments(DateTime StartDate, DateTime EndDate);
    Task<IResult> CreateAppointment(AppointmentDto appointment);
    Task<IResult> UpdateAppointment(AppointmentDto appointment);

    Task<IResult<AppointmentDto>> GetAppointment(int id);
    Task<IResult> SaveAppointment(int id, AppointmentDto appointment);
    Task<IResult> CancelAppointment(int id, int cancelReasonId);
    Task<IResult> DeleteAppointment(int id);
}