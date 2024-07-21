namespace Services.Features.UserAccounts.Dtos.User;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string FullName{ get; set; }
    
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string Phone { get; set; }
    public string Mcn { get; set; }
    public string Ban { get; set; }
    public string Email { get; set; }
    public string UserType { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ResetPasswordAt { get; set; } 

    public Guid RoleId { get; set; }
    public bool IsActive { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
    public bool IsUpdatePassword { get; set; }
    public bool IsForceReset { get; set; }
    public RoleResponseDto Role { get; set; }

}