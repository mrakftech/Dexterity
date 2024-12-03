using Domain.Contracts;

namespace Domain.Entities.Settings.Templates.InvestigationTemplates;

public class InvestigationDetail : IBaseId
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsMaindatory { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FieldType { get; set; }
    public double AbsoluteMinimum { get; set; }
    public double AbsoluteMaximum { get; set; }
    public double NormalMinimum { get; set; }
    public double NormalMaximum { get; set; }
    public string Unit { get; set; }

    public Investigation Investigation { get; set; }
    public Guid InvestigationId { get; set; }

    public InvestigationSelectionList InvestigationSelectionList { get; set; }
    public Guid? InvestigationSelectionListId { get; set; }
}