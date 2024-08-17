namespace Services.Features.PatientManagement.Dtos.Details;

public class PatientListDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string AddressLine1 { get; set; }
    public string Mobile { get; set; }
    public string IhiNumber { get; set; }
}