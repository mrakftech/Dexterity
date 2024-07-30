using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings;
using Domain.Entities.UserAccounts;
using Heron.MudCalendar;
using Services.Features.PatientManagement.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Services.Features.Appointments.Dtos;

public class AppointmentDto 
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public bool IsAllDay { get; set; }
    public string RecurrenceRule { get; set; }
    public string RecurrenceException { get; set; }
    public Nullable<int> RecurrenceID { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
    public int CancelReasonId { get; set; }
    public int AppointmentTypeId { get; set; }
    public int ClinicId { get; set; }
    public Guid PatientId { get; set; }
    public Guid HcpId { get; set; }

}