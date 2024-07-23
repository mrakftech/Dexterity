namespace Services.Features.UserAccounts.Dtos.User;

public class LoginResponseDto
{
    public Guid UserId { get; set; }
    public string RoleName { get; set; }
    public string Name { get; set; }
    public bool IsForceReset { get; set; }

    public int ClinicId { get; set; }

}