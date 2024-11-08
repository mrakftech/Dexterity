using System.ComponentModel.DataAnnotations;
using Domain.Entities.Settings.Templates;

namespace Services.Features.Settings.Dtos;

public class InvestigationTemplateDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    public bool IsActive { get; set; }
}