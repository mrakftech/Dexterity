using Domain.Contracts;

namespace Domain.Entities.Consultation.Investigation;

public class InvestigationAudit : IBaseId
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string HcpName { get; set; }
    public PatientInvestigation PatientInvestigation { get; set; }
    public Guid PatientInvestigationId { get; set; }
}