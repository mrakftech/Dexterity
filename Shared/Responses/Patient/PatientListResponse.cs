namespace Shared.Responses.Patient;

public class PatientListResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }    
    public string FullName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string EmailAddress { get; set; }
    public string AddressLine1 { get; set; }
    public string Mobile { get; set; }
}