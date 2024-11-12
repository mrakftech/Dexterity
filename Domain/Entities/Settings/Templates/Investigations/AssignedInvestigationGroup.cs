namespace Domain.Entities.Settings.Templates.Investigations;

public class AssignedInvestigationGroup
{
    public Guid Id { get; set; }
    public InvestigationGroup InvestigationGroup { get; set; }
    public Guid InvestigationGroupId { get; set; }
    
    public Investigation Investigation { get; set; }
    public Guid InvestigationId { get; set; }
}