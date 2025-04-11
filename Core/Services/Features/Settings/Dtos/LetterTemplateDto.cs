using System.ComponentModel.DataAnnotations;
using Shared.Attributes;

namespace Services.Features.Settings.Dtos;

public class LetterTemplateDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    public bool IsActive { get; set; }
    public string TemplateFile { get; set; }
    [NotEmpty(ErrorMessage = "Required")] public Guid LetterTypeId { get; set; }

    public string TemplateType { get; set; } = "New";
}