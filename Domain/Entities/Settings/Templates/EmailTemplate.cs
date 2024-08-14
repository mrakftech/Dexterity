using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Settings.Templates;

public class EmailTemplate
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    [Required(ErrorMessage = "Required")] public string Content { get; set; }
}