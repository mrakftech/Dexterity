using Services.Features.WaitingRoom.Dtos;
using Shared.Constants.Module;
using Shared.Wrapper;

namespace Services.Features.WaitingRoom.Service;

public interface IWaitingRoomService
{
    Task<List<WaitingPatientDto>> GetExpectedPatients(string status = AppointmentConstants.WaitingStatus.Expected);
    Task<List<WaitingPatientDto>> GetAllWaitingPatients();
    Task<List<WaitingPatientDto>> GetWaitingPatients(string status = AppointmentConstants.WaitingStatus.Expected);
    Task<IResult> UpdateWaitingAppointment(int appointmentId, string status);
}