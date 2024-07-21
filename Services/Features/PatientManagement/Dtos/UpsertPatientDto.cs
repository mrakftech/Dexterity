using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos;

public class UpsertPatientDto 
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; } = DateTime.Today.Date;
    [Required] public string Gender { get; set; }
    [Required] public string Mobile { get; set; }
    [Required] public string EmailAddress { get; set; }
    [Required] public string AddressLine1 { get; set; }
    public string HomePhone { get; set; }
    [Required] public string Ppsn { get; set; }
    public string AddressLine2 { get; set; }
    public string PatientType { get; set; }
    
    public string GmsNumber { get; set; }
    public string GmsDoctorNumber { get; set; }
    public DateTime Expiry { get; set; }
    
    
    public string Error { get; set; }

   
}