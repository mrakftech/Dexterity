namespace Services.Features.Consultation.Dto;

public class GetPrescriptionDto
{
    public Guid Id { get; set; }
    public string DrugName { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string AddedBy { get; set; }

}