using Heron.MudCalendar;
using Services.Features.PatientManagement.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Services.Features.Appointments.Dtos;

public class GetAppointmentDto : CalendarItem
{
    public new Guid Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    public int Duration { get; set; } = 15;
    public string Notes { get; set; }
    [Required] public string Type { get; set; }


    public Guid PatientId { get; set; }
    public PatientListDto Patient { get; set; }
    public Guid HcpId { get; set; }
}