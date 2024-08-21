using Services.Features.PatientManagement.Dtos.Family;

namespace Services.Features.PatientManagement.Dtos.Details;

public class PatientSummaryDto
{
    public Guid Id { get; set; }
    public string UniqueNumber { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; } = "";
    public string Status { get; set; }
    public string Type { get; set; }
    public string DateOfBirth { get; set; }
    public string Ppsn { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string DefualtHcp { get; set; }
    public string RegistrationDate { get; set; }

    public string HospitalNo { get; set; }
    public List<FamilyMemberDto> FamilyMembers { get; set; } = new();
    public string NextOfKin { get; set; }
    public string Relationship { get; set; }
    public string KinContact { get; set; }
    public string KinAddress { get; set; }
    
    public string GmsStatus { get; set; }
    public string GmsDoctor { get; set; }
    public string GmsNumber { get; set; }
    public string GmsReviewDate { get; set; }
    public string GmsDistance { get; set; }

    public List<PatientHospitalDto> Hospitals { get; set; } = new();
    public string HospitalNumber { get; set; } 

}