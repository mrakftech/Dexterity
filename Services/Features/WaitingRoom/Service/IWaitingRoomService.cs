using Services.Features.WaitingRoom.Dtos;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.WaitingRoom.Service;

public interface IWaitingRoomService
{
    Task<List<WaitingPatientDto>> GetWaitingRoomPatients(string status = AppointmentConstants.WaitingStatus.Expected);
    Task<List<WaitingPatientDto>> GetVisitHistory();
    Task<IResult> UpdateWaitingAppointment(Guid appointmentId, string status, Guid consultationId = default);
}