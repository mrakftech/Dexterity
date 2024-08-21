using System.ComponentModel.DataAnnotations;
using Shared.Constants.Module;

namespace Services.Features.PatientManagement.Dtos.Family;

public class FamilyMemberDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name = "Family Name")]
    public string FamilyName { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Required")] 
    public string Title { get; set; }
    public Gender Gender { get; set; }
    [Required(ErrorMessage = "Required")] public string Address { get; set; }
    
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Contact Detail")]
    public string ContactDetail { get; set; }
    
    [Required(ErrorMessage = "Required")] 
    [Display(Name = "Relationship To Patient")]
    public string RelationshipToPatient { get; set; }
    public bool IsCarer { get; set; }

    public Guid PatientId { get; set; }
}