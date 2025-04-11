namespace Services.Features.Consultation.Dto.Investigations;

public class ResultInvestigationDto
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
    public string ResultText { get; set; }
    public string ResultSelectedValue { get; set; }
    public DateTime ResultDate { get; set; } = DateTime.Now;
    public int ResultNumber { get; set; }
    public decimal ResultDecimal { get; set; }
    public string Range { get; set; }

    public Guid InvestigationId { get; set; }
    public Guid InvestigationDetailId { get; set; } 

}