using Domain.Contracts;

namespace Domain.Entities.Consultation;

public class LetterReply : IBaseId
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }
    public string AdditionNotes { get; set; }
    public string File { get; set; }

    public ConsultationLetter ConsultationLetter { get; set; }
    public Guid ConsultationLetterId { get; set; }
}