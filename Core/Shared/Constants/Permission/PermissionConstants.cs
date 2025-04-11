namespace Shared.Constants.Permission;

public static class PermissionConstants
{
    public const string Create = "Create";
    public const string Update = "Update";
    public const string Read = "Read";
    public const string Delete = "Delete";
    public const string Print = "Print";
    
    public static List<string> AllClaims { get; set; } =
    [
        "Print",
        "Delete",
        "Update",
        "Read",
        "Create",
    ];


    
}

