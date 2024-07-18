namespace Shared.Responses.UserAccounts;

public class LoginResponse
{
    public Guid UserId { get; set; }
    public string RoleName { get; set; }
    public bool IsForceReset { get; set; }

}