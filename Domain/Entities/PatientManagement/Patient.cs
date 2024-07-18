using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities.PatientManagement;

public class Patient : IBaseId, IBaseActionOn, IBaseActionBy
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }=DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }

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

    [Required] public DateOnly DateOfBirth { get; set; }
    [Required] public string Gender { get; set; }
    [Required] public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string PatientType { get; set; }
    public string PatientStatus { get; set; }
    public string Ppsn { get; set; }
    public string IhINumber { get; set; }
    public string Title { get; set; } //(e.g. Dr or Mr or Ms, etc.)
    [Required] public string Mobile { get; set; }
    [Required] public string EmailAddress { get; set; }
    public string HomePhone { get; set; }
    public string UniqueNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}