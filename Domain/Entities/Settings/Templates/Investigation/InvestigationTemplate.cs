using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Templates.Investigation;

public class InvestigationTemplate : IBaseId
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public ICollection<InvestigationTemplateDetail> InvestigationDetails { get; set; }

}