using Domain.Contracts;
using Domain.Entities.Consultation;
using Domain.Entities.Consultation.Immunisations;
using Domain.Entities.Messaging;
using Domain.Entities.PatientManagement;

namespace Domain.Entities.UserAccounts;

public class User : IBaseId, IBaseActionOn, IBaseActionBy
{
    public User()
    {
        ChatMessagesFromUsers = new HashSet<ChatMessage>();
        ChatMessagesToUsers = new HashSet<ChatMessage>();
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

    public string MobileNumber { get; set; }
    public string FaxNo { get; set; }
    public string TelePhone { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string Address4 { get; set; }
    public string Gender { get; set; }
    public string MedCouncilNumber { get; set; }
    public string GsmNumber { get; set; }
    public string BordAltranaisNumber { get; set; }
    public string PasswordHash { get; set; }
    public string Mcn { get; set; } = default!;
    public string Ban { get; set; } = default!;
    public bool IsUpdatePassword { get; set; }
    public bool IsForceReset { get; set; }
    public DateTime ResetPasswordAt { get; set; } = default!;
    public string ResetPassword { get; set; }

    public DateTime? ModifiedDate { get; set; } = null;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = false;
    public bool IsLockOut { get; set; } = false;

    public int FailedAttempted { get; set; }

    public TimeSpan StartHour { get; set; } = new(9, 0, 0);
    public TimeSpan EndHour { get; set; } = new(17, 0, 0);
    public int SlotInterval { get; set; } = 15;
    public int[] WorkingDays { get; set; } = [1, 2, 3, 4, 5];

    public Role Role { get; set; }
    public Guid RoleId { get; set; }

    public UserType UserType { get; set; }
    public Guid UserTypeId { get; set; }
    public virtual ICollection<UserClinic> UserClinics { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }
    public virtual ICollection<ChatMessage> ChatMessagesFromUsers { get; set; }
    public virtual ICollection<ChatMessage> ChatMessagesToUsers { get; set; }
    public virtual ICollection<AdministerShot> AdministerShots { get; set; }
}