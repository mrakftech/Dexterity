using System.ComponentModel.DataAnnotations;
using Shared.Attributes;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Details;

public class QuickAddPatientDto
{
    [Required(ErrorMessage = "*")]
    [Display(Name = "Family Name*")]
    public string FamilyName { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "First Name*")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "*")]
    [Display(Name = "Last Name*")]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; } = DateTime.Today;
    [Required(ErrorMessage = "*")] public Gender Gender { get; set; }
    [Required(ErrorMessage = "*")] public string AddressLine1 { get; set; }
    [Required(ErrorMessage = "*")] public string Mobile { get; set; }

    [Required(ErrorMessage = "*")] public string Email { get; set; }

    [NotEmpty(ErrorMessage = "*")] public Guid HcpId { get; set; }
}