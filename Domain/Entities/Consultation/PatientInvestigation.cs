using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Templates.Investigations;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Consultation
{
    public class PatientInvestigation
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;
        public string Status { get; set; } //Awaiting, In Review, Follow up, Complete

        public bool IsAbnormal { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public User Hcp { get; set; }
        public Guid HcpId { get; set; }

        public Investigation Investigation { get; set; }
        public Guid InvestigationId { get; set; }
    }
}