using Domain.Contracts;

namespace Domain.Entities.PatientManagement.Alert;

public class PatientAlert : IBaseId, IBaseActionBy, IBaseActionOn
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }

    public string Type { get; set; }
    public string Severity { get; set; }
    public string Details { get; set; }
    public bool IsResolved { get; set; }


    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
    
    public AlertCategory AlertCategory { get; set; }
    public int AlertCategoryId { get; set; }
}