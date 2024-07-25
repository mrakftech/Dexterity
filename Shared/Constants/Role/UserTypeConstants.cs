namespace Shared.Constants.Role;

public static class UserTypeConstants
{
    public const string Doctor = "Doctor";
    public const string Nurse = "Nurse";

    public static List<string> UserTypes { get; set; } =
    [
        Doctor,
        Nurse
    ];
}