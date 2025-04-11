using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.Settings.Templates.InvestigationTemplates;

public class Investigation : IBaseId
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public ICollection<InvestigationDetail> InvestigationDetails { get; set; }

}