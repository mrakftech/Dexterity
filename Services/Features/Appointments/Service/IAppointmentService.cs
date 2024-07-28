using Services.Features.Appointments.Dtos;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.Appointments.Service;

public interface IAppointmentService
{
    Task<List<GetAppointmentDto>> GetAppointments(string status = null);
    Task<List<GetAppointmentDto>> GetAppointmentsByHcp(Guid hcpId);
    Task<IResult<GetAppointmentDto>> GetAppointment(Guid id);
    Task<IResult> SaveAppointment(Guid id, UpsertAppointmentDto appointment);
    Task<IResult> CancelAppointment(Guid id, int cancelReasonId);
}