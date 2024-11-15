namespace Services.Features.Consultation.Dto.Investigations;

public class UpdateResultDto
{
    public Guid Id { get; set; } 
    public string FieldType { get; set; }
    public string ResultText { get; set; }
    public string ResultSelectedValue { get; set; }
    public DateTime ResultDate { get; set; } = DateTime.Now;
    public int ResultNumber { get; set; }
    public decimal ResultDecimal { get; set; }

}