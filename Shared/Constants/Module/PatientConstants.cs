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
        public string Private = PatientTypes.Private.ToString();
        public string Gms = PatientTypes.GMS.ToString();
        public string VisitCard = PatientTypes.DoctorVisitCard.ToString();
        public string Other = PatientTypes.Other.ToString();
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
            Garda ,
            Others ,
        ];

    }


    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Others")]
        Others
    }

    public static List<Ethnicity> Ethnicities { get; set; } = new List<Ethnicity>()
    {
        new(1,"White Irish"),
        new (2,"Irish Travelers"),
        new (3,"Other White"),
        new (4,"Black Irish or African"),
        new (5,"Other Black"),
        new (6,"Chinese"),
        new (7,"Other Asian"),
        new (8,"Other"),
        new (9,"Not stated"),
    };


}


public class Ethnicity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Ethnicity(int id, string name)
    {
        Id = id;
        Name = name;
    }
}