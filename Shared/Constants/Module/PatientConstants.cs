using System.ComponentModel.DataAnnotations;

namespace Shared.Constants.Module;

public static class PatientConstants
{

    public static List<Ethnicity> Ethnicities { get; set; } =
    [
        new Ethnicity(1, "White Irish"),
        new Ethnicity(2, "Irish Travelers"),
        new Ethnicity(3, "Other White"),
        new Ethnicity(4, "Black Irish or African"),
        new Ethnicity(5, "Other Black"),
        new Ethnicity(6, "Chinese"),
        new Ethnicity(7, "Other Asian"),
        new Ethnicity(8, "Other"),
        new Ethnicity(9, "Not stated")
    ];

    public static List<MaritalStatus> MaritalStatusList { get; set; } =
    [
        new MaritalStatus(1, "Married"),
        new MaritalStatus(2, "Divorced"),
        new MaritalStatus(3, "Seprated"),
        new MaritalStatus(4, "Widowed"),
        new MaritalStatus(5, "Single"),
    ];

    public static List<Relationship> RelationshipList { get; set; } =
    [
        new Relationship(1, "Aunt"),
        new Relationship(1, "Uncle"),
        new Relationship(2, "Spouse"),
        new Relationship(3, "Siblings"),
        new Relationship(4, "Cousin"),
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

public enum AccountType
{
    Personal,
    Group,
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
    Payment
}
