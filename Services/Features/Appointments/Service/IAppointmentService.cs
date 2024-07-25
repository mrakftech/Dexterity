using Services.Features.Appointments.Dtos;

namespace Services.Features.Appointments.Service;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAppoinments();
}