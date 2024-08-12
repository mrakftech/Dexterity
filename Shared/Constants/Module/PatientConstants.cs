using System.ComponentModel.DataAnnotations;

namespace Shared.Constants.Module;

public static class PatientConstants
{
    public class Status
    {
        public string Active = PatientStatus.Active.ToString();
        public string InActive = PatientStatus.Inactive.ToString();
        public string Nullified = PatientStatus.Nullified.ToString();
        public string Obsolete = PatientStatus.Obsolete.ToString();

        public enum PatientStatus
        {
            Active,
            Inactive,
            Nullified,
            Obsolete,
        }
    }
    public class PatientType
    {
        public static string Private = PatientTypes.Private.ToString();
        public static string Gms = PatientTypes.GMS.ToString();
        public static string VisitCard = PatientTypes.DoctorVisitCard.ToString();
        public static string Other = PatientTypes.Other.ToString();

        public enum PatientTypes
        {
            Private,
            DoctorVisitCard,
            GMS,
            Other
        }
    }
    public class CompanyMedicalScheme
    {
        public const string AnPost = "An Post";
        public const string Garda = "Garda";
        public const string Others = "Others";

        public static List<string> CompanyMedicalSchemes { get; set; } =
        [
            AnPost,
            Garda,
            Others,
        ];
    }

    public enum Gender
    {
        [Display(Name = "Male")] Male,
        [Display(Name = "Female")] Female,
        [Display(Name = "Others")] Others
    }

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
    
    public class AlertType
    {
        public string Appointment = AlertTypes.Appointment.ToString();
        public string Account = AlertTypes.Account.ToString();
        public string Consultation = AlertTypes.Consultation.ToString();
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

public enum AlertTypes
{
    Appointment,
    Account,
    Consultation
}

public enum AlertSeverity
{
    Low,
    Medium,
    High
}