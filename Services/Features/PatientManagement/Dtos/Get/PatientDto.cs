using Domain.Entities.PatientManagement.BasicDetails;
using Domain.Entities.PatientManagement.Extra;

namespace Services.Features.PatientManagement.Dtos.Get;

public class PatientDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime DisRegistrationDate { get; set; }
    public string DisRegistrationReason { get; set; }

    public string FamilyName { get; set; }
    public string FormerFamilyName { get; set; }
    public string Alias { get; set; }
    public string BirthSurname { get; set; }
    public string MotherMaidenName { get; set; }
    public bool DispensingStatus { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName
    {
        get => $"{FirstName} {LastName}";
        set
        {
            var parts = value.Split(' ');
            if (parts.Length == 2)
            {
                FirstName = parts[0];
                LastName = parts[1];
            }
            else
            {
                FirstName = value;
                LastName = string.Empty;
            }
        }
    }

    public string Title { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string MedicalRecordNumber { get; set; }
    public string HomePhone { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public string PatientType { get; set; }
    public string Status { get; set; }
    public string Photo { get; set; }


    public string Ppsn { get; set; }
    public string IhiNumber { get; set; }


    public string CompanyMedicalScheme { get; set; }
    public string EnrollmentStatus { get; set; }
    public DateTime DateOfEnrollment { get; set; }
    public DateTime DateOfDeath { get; set; }
    public string CauseOfDeath { get; set; }

    public PatientAddress Address { get; set; } = new();
    public MedicalCardDetail MedicalCardDetails { get; set; } = new();

    public OtherDetail OtherDetails { get; set; }
    public MaritalDetail MaritalDetails { get; set; }
    public DrugPaymentSchemeDetail DrugPaymentSchemeDetails { get; set; } = new();
    public PrivateHealthInsuranceDetail PrivateHealthInsuranceDetails { get; set; } = new();

    public Guid HcpId { get; set; }
    public int ClinicId { get; set; }
}