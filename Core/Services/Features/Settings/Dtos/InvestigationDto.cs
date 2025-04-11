using System.ComponentModel.DataAnnotations;

namespace Services.Features.Settings.Dtos;

public class InvestigationDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    public bool IsActive { get; set; }
}