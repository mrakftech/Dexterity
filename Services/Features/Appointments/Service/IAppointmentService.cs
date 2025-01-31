using Domain.Entities.Appointments;
using Services.Features.Appointments.Dtos;
using Shared.Wrapper;

namespace Services.Features.Appointments.Service;

public interface IAppointmentService
{
    Task<List<SearchAppointmentDto>> FindAppointments();
    Task<List<AppointmentHistoryDto>> GetAppointmentHistory(Guid patientId);
    Task<List<AppointmentDto>> GetAllAppointments(DateTime startDate, DateTime endDate);
    Task<IResult<AppointmentDto>> GetAppointment(Guid id);

    Task<IResult> CreateAppointment(AppointmentDto appointment);
    Task UpdateAppointment(AppointmentDto appointment);
    Task DeleteAppointment(Guid id);
    Task<IResult> DeleteAppointmentSeries(Guid id);
    Task<IResult> CancelAppointment(Guid appointmentId, int cancelReasonId);
    Task<IResult> SaveAppointment(Guid id, AppointmentDto appointment);

    #region Recurring
    Task<bool> IsSlotAvaiable(DateTime date, Guid hcpId);
    Task<List<AppointmentSlotDto>> GetAllFreeSlots();
    Task<List<AppointmentSlotDto>> GetFreeSlots(DateTime startDate, DateTime endDate, Guid hcpId,int duration);
    Task<IResult> AddRecurrenceEvents(List<AppointmentSlotDto> appointments,AppointmentDto appointment);
    Task<IResult> AddRecurrenceEventsSlot(List<DateTime> recurrencDates, DateTime startDate,Guid hcpId);
    Task<IResult> ClearRecurrenceEventsSlots();
    Task<IResult> SelectFreeSlot(Guid id,DateTime startDate);

    #endregion
}