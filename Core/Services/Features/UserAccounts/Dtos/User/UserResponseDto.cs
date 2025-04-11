namespace Services.Features.UserAccounts.Dtos.User;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string FullName{ get; set; }
    
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string Mcn { get; set; }
    public string Ban { get; set; }
    public string Email { get; set; }
    public string UserType { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ResetPasswordAt { get; set; } 

    public bool IsActive { get; set; } = false;
    public bool IsLockOut { get; set; } = false;
    public bool IsUpdatePassword { get; set; }
    public bool IsForceReset { get; set; }
    public RoleResponseDto Role { get; set; }
    public List<int> WorkingDays { get; set; }
    public TimeSpan StartHour { get; set; }
    public TimeSpan EndHour { get; set; }
    public int SlotInterval { get; set; }

    public string MobileNumber { get; set; }
    public string FaxNo { get; set; }
    public string TelePhone { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string Address4 { get; set; }
    public string Gender { get; set; }
    public string MedCouncilNumber { get; set; }
    public string GsmNumber { get; set; }
    public string BordAltranaisNumber { get; set; }
    public Guid UserTypeId { get; set; }
    public Guid RoleId { get; set; }

    public bool IsOnline { get; set; }

}