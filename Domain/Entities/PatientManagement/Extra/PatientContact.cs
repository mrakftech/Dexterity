namespace Domain.Entities.PatientManagement.Extra;

public class PatientContact
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}