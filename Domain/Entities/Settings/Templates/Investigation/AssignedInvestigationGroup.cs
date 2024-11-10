namespace Domain.Entities.Settings.Templates.Investigation;

public class AssignedInvestigationGroup
{
    public Guid Id { get; set; }
    public InvestigationGroup InvestigationGroup { get; set; }
    public Guid InvestigationGroupId { get; set; }
    public InvestigationTemplate InvestigationTemplate { get; set; }
    public Guid InvestigationTemplateId { get; set; }
}