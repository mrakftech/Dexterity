using System.ComponentModel.DataAnnotations;

namespace Services.Features.Settings.Dtos;

public class ClinicDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    [Required(ErrorMessage = "Required")] public string Address { get; set; }
    [Required(ErrorMessage = "Required")] public string Contact { get; set; }
}