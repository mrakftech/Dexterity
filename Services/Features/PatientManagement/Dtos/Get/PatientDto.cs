using System.ComponentModel.DataAnnotations;

namespace Services.Features.PatientManagement.Dtos.Get;

public class PatientDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.Today;
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }

    #region Registration Data

    [Required] public string FamilyName { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Today;
    [Required] public string Gender { get; set; }
    [Required] public string AddressLine1 { get; set; }
    public string Mobile { get; set; }
    #endregion
}