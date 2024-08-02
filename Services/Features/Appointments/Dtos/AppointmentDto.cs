
namespace Services.Features.Appointments.Dtos;

public class AppointmentDto 
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Location { get; set; }
    public DateTime StartTime { get; set; } =DateTime.Now;
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public bool IsAllDay { get; set; }
    public string RecurrenceRule { get; set; }
    public string RecurrenceException { get; set; }
    public int? RecurrenceID { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
    public int CancelReasonId { get; set; }
    public int AppointmentTypeId { get; set; }
    public int ClinicId { get; set; }
    public int ClinicSiteId { get; set; }
    public Guid PatientId { get; set; }
    public Guid HcpId { get; set; }

    public string Type { get; set; }
    public string PatientName { get; set; }
}