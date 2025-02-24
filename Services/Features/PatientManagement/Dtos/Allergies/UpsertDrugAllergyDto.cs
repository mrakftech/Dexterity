using Services.State;

namespace Services.Features.PatientManagement.Dtos.Allergies;

public class UpsertDrugAllergyDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string DrugType { get; set; } = "Allergy";
    public string DrugAllergyName { get; set; } = "Paracetamol";
    public string Notes { get; set; }
    public int DrugId { get; set; }
    public Guid PatientId { get; set; } = ApplicationState.SelectedPatient.Id;
    public string PatientName { get; set; } = ApplicationState.SelectedPatient.Name;

}