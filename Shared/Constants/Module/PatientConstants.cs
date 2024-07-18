namespace Shared.Constants.Module;

public static class PatientConstants
{
    public static List<string> PatientTypes { get; set; } =
    [
        "Private",
        "GMS",
        "Doctor Visit Card",
        "Other"
    ];
    public static List<string> PatientStatus { get; set; } =
    [
        "Active",
        "Inactive",
    ];
    public static List<string> Title { get; set; } =
    [
        "Miss",
        "Mr.",
        "Dr.",
    ];
    public static List<string> CompanyMedicalSchemes { get; set; } =
    [
        "An Post",
        "Garda",
        "Others"
    ];
    public static List<string> Gender { get; set; } =
    [
        "Male",
        "Female"
    ];
    
    public static List<string> Ethnicities { get; set; } =
    [
        "White Irish",
        "Irish Travelers",
        "other White",
        "Black Irish or African",
        "other Black",
        "Chinese",
        "other Asian",
        "Other",
        "Not stated"
    ];
}