using Shared.Constants.Module.Consultation;

namespace Domain.Entities.Consultation;

public class ConsultationNote
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = NotesStatus.None;
    public string Notes { get; set; }

    public ConsultationDetail ConsultationDetail { get; set; }
    public int ConsultationDetailId { get; set; }
}