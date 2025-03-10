using Domain.Entities.UserAccounts;

namespace Services.Features.UserAccounts.Dtos.User;

public class LoginResponseDto
{
    public Guid UserId { get; set; }
    public string RoleName { get; set; }
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public bool IsForceReset { get; set; }
    public bool IsAdmin { get; set; }

    public int ClinicId { get; set; }
    public int[] WorkingDays { get; set; }
    public TimeSpan StartHour { get; set; }
    public TimeSpan EndHour { get; set; }
    public DateTime ResetPasswordAt { get; set; }

    public List<PermissionClaim> PermissionClaims { get; set; }

}