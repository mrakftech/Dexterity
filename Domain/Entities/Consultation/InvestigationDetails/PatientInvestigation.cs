using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.UserAccounts;
using Shared.Attributes;

namespace Domain.Entities.Consultation.InvestigationDetails
{
    public class PatientInvestigation:IBaseId,IBaseActionOn
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;
        public string Status { get; set; } //Awaiting, In Review, Follow up, Complete

        public bool IsAbnormal { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public User Hcp { get; set; }
        [NotEmpty(ErrorMessage = "Required")] public Guid HcpId { get; set; }

        public Settings.Templates.InvestigationTemplates.Investigation Investigation { get; set; }
        public Guid InvestigationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual ICollection<InvestigationAudit> InvestigationAudits { get; set; }

    }
}