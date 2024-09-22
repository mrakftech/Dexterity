namespace Domain.Entities.PatientManagement.Allergies;

public class PatientAllergy
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string AllergyName { get; set; }
    public string Notes { get; set; }
    public Guid PatientId { get; set; }
}