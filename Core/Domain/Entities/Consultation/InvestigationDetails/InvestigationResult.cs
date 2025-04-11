using Domain.Contracts;
using Domain.Entities.Settings.Templates.InvestigationTemplates;

namespace Domain.Entities.Consultation.InvestigationDetails;

public class InvestigationResult : IBaseId
{
    public Guid Id { get; set; }
    public string Result { get; set; }
    public Settings.Templates.InvestigationTemplates.InvestigationDetail InvestigationDetail { get; set; }
    public Guid? InvestigationDetailId { get; set; }
    
    public PatientInvestigation PatientInvestigation { get; set; }
    public Guid? PatientInvestigationId { get; set; }
    
}