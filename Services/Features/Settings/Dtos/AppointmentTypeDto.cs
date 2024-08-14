using System.ComponentModel.DataAnnotations;

namespace Services.Features.Settings.Dtos;

public class AppointmentTypeDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    public int Duration { get; set; }
    public bool Active { get; set; } = true;
}