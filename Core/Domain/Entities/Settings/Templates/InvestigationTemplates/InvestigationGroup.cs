using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Templates.InvestigationTemplates;

public class InvestigationGroup : IBaseId
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Required")] public string Name { get; set; }
    public string Icon { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}