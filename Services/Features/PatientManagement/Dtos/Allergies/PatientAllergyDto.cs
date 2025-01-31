using Services.State;

namespace Services.Features.PatientManagement.Dtos.Allergies;

public class PatientAllergyDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string AllergyName { get; set; }
    public string Notes { get; set; }
    public bool IsDrugAllergy { get; set; }
    public string DrugType { get; set; }
    public string DrugAllergyName { get; set; }
    
    public Guid PatientId { get; set; } = ApplicationState.SelectedPatient.PatientId;
}