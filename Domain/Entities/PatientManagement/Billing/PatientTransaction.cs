using Domain.Contracts;

namespace Domain.Entities.PatientManagement.Billing;

public class PatientTransaction : IBaseActionBy, IBaseActionOn
{
    public int Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }

    public decimal Balance { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}