using Heron.MudCalendar;
using Services.Features.PatientManagement.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Services.Features.Appointments.Dtos;

public class GetAppointmentDto 
{
    public  Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Title { get; set; }
    public string Subject { get; set; }
    public string Color { get; set; }
    public int Duration { get; set; } = 15;
    public string Notes { get; set; }
    public string Type { get; set; }

    public Guid PatientId { get; set; }
    public PatientListDto Patient { get; set; }
    public Guid HcpId { get; set; }

    public bool IsAllDay { get; set; }
    public string RecurrenceRule { get; set; }
    public string RecurrenceException { get; set; }
    public Nullable<int> RecurrenceID { get; set; }
}