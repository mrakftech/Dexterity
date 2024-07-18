using Domain.Contracts;

namespace Domain.Entities.UserAccounts;

public class PermissionClaim: IBaseId
{
    public Guid Id { get; set; }
    public string ModuleName { get; set; }
    public string ClaimName { get; set; } 
    public bool Allowed { get; set; }

    public Role Role { get; set; }
    public Guid RoleId { get; set; }
}