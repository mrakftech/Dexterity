using System.ComponentModel.DataAnnotations;
using Shared.Attributes;
using Shared.Constants.Module;
using static Shared.Constants.Module.PatientConstants;

namespace Services.Features.PatientManagement.Dtos.Details;

public class QuickAddPatientDto
{
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Family Name")]
    public string FamilyName { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; } = DateTime.Today;
    [Required(ErrorMessage = "Required")] public Gender Gender { get; set; }
    [Required(ErrorMessage = "Required")] public string AddressLine1 { get; set; }
    [Required(ErrorMessage = "Required")] public string Mobile { get; set; }

    [Required(ErrorMessage = "Required")] public string Email { get; set; }

    [NotEmpty(ErrorMessage = "Required")] public Guid HcpId { get; set; }
}