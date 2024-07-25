using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities.Settings;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.PatientManagement;

public class Patient : IBaseId, IBaseActionOn, IBaseActionBy
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }

    [Required] public string FamilyName { get; set; }

    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }

    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
        set
        {
            var parts = value.Split(' ');
            if (parts.Length == 2)
            {
                FirstName = parts[0];
                LastName = parts[1];
            }
            else
            {
                FirstName = value;
                LastName = string.Empty;
            }
        }
    }

    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string AddressLine1 { get; set; }
    public string Mobile { get; set; }
    public string EmailAddress { get; set; }

    public User HealthCareProfessional { get; set; }
    public Guid HealthCareProfessionalId { get; set; }
    public Clinic Clinic { get; set; }
    public int ClinicId { get; set; }
}