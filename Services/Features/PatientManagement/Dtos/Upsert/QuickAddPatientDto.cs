using System.ComponentModel.DataAnnotations;
using static Shared.Constants.Module.PatientConstants;

namespace Services.Features.PatientManagement.Dtos.Upsert;

public class QuickAddPatientDto
{
    [Required] public string FamilyName { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Today;
    [Required] public Gender Gender { get; set; }
    [Required] public string AddressLine1 { get; set; }
    [Required] public string Mobile { get; set; }

    [Required] public string EmailAddress { get; set; }

    public Guid HcpId { get; set; }

}