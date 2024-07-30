using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings;

namespace Domain.Entities.UserAccounts;

public class User : IBaseId, IBaseActionOn, IBaseActionBy
{
    public User()
    {
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }

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

    public string Phone { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string UserType { get; set; }
    public string Mcn { get; set; } = default!;
    public string Ban { get; set; } = default!;
    public bool IsUpdatePassword { get; set; }
    public bool IsForceReset { get; set; }
    public DateTime ResetPasswordAt { get; set; } = default!;
    public DateTime? ModifiedDate { get; set; } = null;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
    public Role Role { get; set; }
    public Guid RoleId { get; set; }


    public virtual ICollection<UserClinic> UserClinics { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }


}