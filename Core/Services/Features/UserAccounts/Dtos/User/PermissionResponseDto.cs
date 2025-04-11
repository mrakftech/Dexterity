namespace Services.Features.UserAccounts.Dtos.User;

public class PermissionResponseDto
{
    public string Module { get; set; }
    public List<string> Claims { get; set; }
    public Guid Id { get; set; }
    public string ModuleName { get; set; }
    public Guid ModuleId { get; set; }
    public string ClaimName { get; set; } 
    public bool Allowed { get; set; }
    public Guid RoleId { get; set; }
}