using Domain.Contracts;
using Domain.Entities.Consultation.Detail;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Consultation;
using Domain.Entities.UserAccounts;
using Shared.Constants.Module.Consultation;

namespace Domain.Entities.Consultation.Notes;

public class ConsultationNote : IBaseId
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsPastHistory { get; set; }
    public bool IsFamilyHistory { get; set; }
    public bool IsActiveCondition { get; set; }
    public bool IsScoialHistory { get; set; }
    public bool IsPrivate { get; set; }
    public string Notes { get; set; }
    public User Hcp { get; set; }
    public Guid HcpId { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public HealthCode HealthCode { get; set; }
    public int? HealthCodeId { get; set; }
}