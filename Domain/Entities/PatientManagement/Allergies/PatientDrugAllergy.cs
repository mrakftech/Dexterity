namespace Domain.Entities.PatientManagement.Allergies;

public class PatientDrugAllergy
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string DrugType { get; set; }
    public string DrugAllergyName { get; set; }
    public int DrugId { get; set; }
    public Guid PatientId { get; set; }
}