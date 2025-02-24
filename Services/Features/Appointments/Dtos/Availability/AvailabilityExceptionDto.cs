using System.ComponentModel.DataAnnotations;
using Shared.Attributes;

namespace Services.Features.Appointments.Dtos.Availability;

public class AvailabilityExceptionDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Type { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month, 1, 9, 00, 0);
    public DateTime EndTime { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month, 1, 9, 00, 0);
    [Required(ErrorMessage = "Required")] public string Reason { get; set; }

    public bool IsBlock { get; set; }
    [NotEmpty(ErrorMessage = "Required")] public Guid HcpId { get; set; }
}