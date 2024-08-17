using Domain.Contracts;

namespace Domain.Entities.PatientManagement.Extra;

public class PatientAccount : IBaseId, IBaseActionBy, IBaseActionOn
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }

    public string AccountType { get; set; }
    public string AccountNotes { get; set; }
    public string InsuranceScheme { get; set; }
    public string PolicyNumber { get; set; }


    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}