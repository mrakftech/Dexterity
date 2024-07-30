using Heron.MudCalendar;
using Services.Features.PatientManagement.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Services.Features.Appointments.Dtos;

public class UpsertAppointmentDto 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    public int Duration { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public string Notes { get; set; }
    public string Status { get; set; }
    public int AppointmentTypeId { get; set; }


    public Guid PatientId { get; set; }
    public Guid HcpId { get; set; }
    public string RecurrenceRule { get; set; }
    public Nullable<int> RecurrenceID { get; set; }
    public string RecurrenceException { get; set; }
}