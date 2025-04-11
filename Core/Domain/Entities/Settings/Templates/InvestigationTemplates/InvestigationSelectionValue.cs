namespace Domain.Entities.Settings.Templates.InvestigationTemplates;

public class InvestigationSelectionValue
{
    public Guid Id { get; set; }
    public string Value { get; set; }

    public InvestigationSelectionList InvestigationSelectionList { get; set; }
    public Guid InvestigationSelectionListId { get; set; }
}