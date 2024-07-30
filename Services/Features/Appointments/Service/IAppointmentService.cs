using Services.Features.Appointments.Dtos;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.Appointments.Service;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAppointments(string status = null);
    Task<List<AppointmentDto>> GetAppointmentsByHcp(Guid hcpId);
    Task<IResult<AppointmentDto>> GetAppointment(int id);
    Task<IResult> SaveAppointment(int id, AppointmentDto appointment);
    Task<IResult> CancelAppointment(int id, int cancelReasonId);
}