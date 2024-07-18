namespace Shared.Requests.UserAccounts;

public class UpdatePermissionRequest
{
    public Guid Id { get; set; }
    public bool Value { get; set; }
}