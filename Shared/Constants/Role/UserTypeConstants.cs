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
    public static List<UserType> UserTypeList { get; set; } =
    [
        new(1, Doctor),
        new(2, Nurse),
    ];
    
    public class UserType(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}