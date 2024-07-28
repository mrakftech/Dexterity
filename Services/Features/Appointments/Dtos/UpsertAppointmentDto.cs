using Heron.MudCalendar;
using Services.Features.PatientManagement.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Services.Features.Appointments.Dtos;

public class UpsertAppointmentDto 
{
    public new Guid Id { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    public int Duration { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string Notes { get; set; }
    public string Status { get; set; }
    public int AppointmentTypeId { get; set; }


    public Guid PatientId { get; set; }
    public Guid HcpId { get; set; }
}