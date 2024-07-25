using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos;

public class UpsertPatientDto
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    [Required] public string FamilyName { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Today;
    [Required] public string Gender { get; set; }
    [Required] public string AddressLine1 { get; set; }
    [Required] public string Mobile { get; set; }

    [Required] public string EmailAddress { get; set; }
    
    public int ClinicId { get; set; }
    public Guid HealthCareProfessionalId { get; set; }

}