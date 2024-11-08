namespace Services.Features.Settings.Dtos;

public class InvestigationTDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsMaindatory { get; set; }
    public string Description { get; set; }
    public string FieldType { get; set; }
    public double AbsoluteMinimum { get; set; }
    public double AbsoluteMaximum { get; set; }
    public double NormalMinimum { get; set; }
    public double NormalMaximum { get; set; }
    public string Unit { get; set; }
    public Guid InvestigationTemplateId { get; set; }

}