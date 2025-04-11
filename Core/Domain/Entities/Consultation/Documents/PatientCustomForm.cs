using Domain.Contracts;
using Domain.Entities.PatientManagement;
using Domain.Entities.Settings.Templates.Forms;
using Domain.Entities.UserAccounts;
using Shared.Attributes;

namespace Domain.Entities.Consultation.Documents;

public class PatientCustomForm : IBaseId
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public string Status { get; set; }
    public string RefNumber { get; set; }
    public CustomFormTemplate FormTemplate { get; set; }
    [NotEmpty(ErrorMessage = "required")] public Guid FormTemplateId { get; set; }

    public User Hcp { get; set; }
    [NotEmpty(ErrorMessage = "required")] public Guid HcpId { get; set; }

    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}