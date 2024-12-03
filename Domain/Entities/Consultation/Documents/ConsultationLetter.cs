using Domain.Contracts;
using Domain.Entities.Settings.Templates.Letter;
using Domain.Entities.UserAccounts;

namespace Domain.Entities.Consultation;

public class ConsultationLetter : IBaseId
{
    public Guid Id { get; set; }
    public DateTime LetterDt { get; set; }
    public string ReferTo { get; set; }
    public string Reference { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CompletedAt { get; set; }
    
    public string PatientFile { get; set; }
    public string PatientFileName { get; set; }

    public Guid LetterTypeId { get; set; }
    public Guid PatientId { get; set; }
    
    public Guid LetterTemplateId { get; set; }
    public LetterTemplate LetterTemplate { get; set; }

    public User Hcp { get; set; }
    public Guid HcpId { get; set; }

    public ICollection<LetterReply> LetterReplies { get; set; }
}