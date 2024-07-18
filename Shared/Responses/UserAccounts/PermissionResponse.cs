namespace Shared.Responses.UserAccounts;

public class PermissionResponse
{
    public string Module { get; set; }
    public List<string> Claims { get; set; }
    public Guid Id { get; set; }
    public string ModuleName { get; set; }
    public string ClaimName { get; set; } 
    public bool Allowed { get; set; }
    public Guid RoleId { get; set; }
}