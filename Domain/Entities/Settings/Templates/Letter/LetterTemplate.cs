using System.ComponentModel.DataAnnotations;
using Shared.Attributes;

namespace Domain.Entities.Settings.Templates.Letter;

public class LetterTemplate
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }

    public bool IsActive { get; set; }
    public string TemplateFile { get; set; }
    public LetterType LetterType { get; set; }
    [NotEmpty] public Guid LetterTypeId { get; set; }
}