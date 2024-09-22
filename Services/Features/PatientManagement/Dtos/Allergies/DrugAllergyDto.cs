namespace Services.Features.PatientManagement.Dtos.Allergies;

public class DrugAllergyDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string DrugType { get; set; }
    public string DrugAllergyName { get; set; }
    public string Notes { get; set; }
    public int DrugId { get; set; }
    
}