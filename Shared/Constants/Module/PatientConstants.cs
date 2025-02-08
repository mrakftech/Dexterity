namespace Shared.Constants.Module;

public static class PatientConstants
{
    public static List<Ethnicity> Ethnicities { get; set; } =
    [
        new(1, "White Irish"),
        new(2, "Irish Travelers"),
        new(3, "Other White"),
        new(4, "Black Irish or African"),
        new(5, "Other Black"),
        new(6, "Chinese"),
        new(7, "Other Asian"),
        new(8, "Other"),
        new(9, "Not stated")
    ];

    public static List<MaritalStatus> MaritalStatusList { get; set; } =
    [
        new(1, "Married"),
        new(2, "Divorced"),
        new(3, "Seprated"),
        new(4, "Widowed"),
        new(5, "Single"),
    ];

    public static List<Relationship> RelationshipList { get; set; } =
    [
        new(1, "Aunt"),
        new(1, "Uncle"),
        new(2, "Spouse"),
        new(3, "Siblings"),
        new(4, "Cousin"),
    ];

    public static string CalculateAge(DateTime dateOfBirth)
    {
        DateTime today = DateTime.Today;
        int years = today.Year - dateOfBirth.Year;
        int months = today.Month - dateOfBirth.Month;
        if (today.Month < dateOfBirth.Month)
        {
            years--;
            months = 12 - dateOfBirth.Month + today.Month;
        }
        else if (today.Month == dateOfBirth.Month)
        {
            if (today.Day < dateOfBirth.Day)
            {
                years--;
                months = 11;
            }
        }

        return $"{years} Yrs {months}m";
    }
}

public class Ethnicity(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

public class MaritalStatus(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

public class Relationship(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

public enum PatientStatus
{
    Active,
    Inactive,
    Nullified,
    Obsolete,
}

public enum PatientType
{
    Private,
    DoctorVisitCard,
    GMS,
    Other
}

public enum CompanyMedicalScheme
{
    AnPost,
    Garda,
    Others,
}

public enum Gender
{
    Male,
    Female,
    Others
}

public enum AlertType
{
    Appointment,
    Account,
    Consultation
}

public enum PatientAccountType
{
    Personal = 1,
    Group = 2,
}

public enum AlertSeverity
{
    Low,
    Medium,
    High
}

public enum TransactionType
{
    Charge,
    Payment,
}
public enum PaymentType
{
    Cash,
}
public enum AccountView
{
    Outstanding,
    Statement,
    History,
    Audit,
    PrintLog
}