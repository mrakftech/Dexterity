using Domain.Contracts;
using Domain.Entities.PatientManagement.Allergies;
using Domain.Entities.PatientManagement.Billing;
using Domain.Entities.PatientManagement.Details;
using Domain.Entities.PatientManagement.Extra;
using Domain.Entities.PatientManagement.Family;
using Domain.Entities.Settings.Clinic;
using Domain.Entities.UserAccounts;
using Domain.Entities.WaitingRoom;
using Shared.Constants.Module;

namespace Domain.Entities.PatientManagement;

public class Patient : IBaseId, IBaseActionOn, IBaseActionBy
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
    public string UniqueNumber { get; set; }
    public string HomePhone { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public string PatientType { get; set; }
    public string Status { get; set; }
    public string Photo { get; set; }
    public bool NkaFlag { get; set; } = true; //No Known Allergies

    public PatientAddress Address { get; set; } = new();
    public MedicalCardDetail MedicalCardDetails { get; set; } = new();
    public OtherDetail OtherDetails { get; set; } = new();
    public MaritalDetail MaritalDetails { get; set; } = new();
    public DrugPaymentSchemeDetail DrugPaymentSchemeDetails { get; set; } = new();
    public PrivateHealthInsuranceDetail PrivateHealthInsuranceDetails { get; set; } = new();
    public string Ppsn { get; set; }
    public string IhiNumber { get; set; }


    public string CompanyMedicalScheme { get; set; }
    public string EnrollmentStatus { get; set; }
    public DateTime DateOfEnrollment { get; set; }
    public DateTime DateOfDeath { get; set; }
    public string CauseOfDeath { get; set; }


    public User Hcp { get; set; }
    public Guid HcpId { get; set; }
    public Clinic Clinic { get; set; }
    public int ClinicId { get; set; }

    public PatientAccount PatientAccount { get; set; } = new();
    public virtual ICollection<PatientHospital> Hospitals { get; set; }
    public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
    public virtual ICollection<WaitingAppointment> WaitingAppointments { get; set; }
}