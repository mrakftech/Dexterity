using Domain.Entities.Settings.Consultation;
using Shared.Constants.Module.Consultation;

namespace Domain.Entities.Consultation;

public class ConsultationNote
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } = NotesStatus.None;
    public string Status { get; set; } = NotesStatus.None;
    public bool IsPastHistory { get; set; }
    public bool IsFamilyHistory { get; set; }
    public bool IsActiveCondition { get; set; }
    public bool IsScoialHistory { get; set; }
    public bool IsPrivate { get; set; }
    public string Notes { get; set; }
    public ConsultationDetail ConsultationDetail { get; set; }
    public int ConsultationDetailId { get; set; }

    public HealthCode HealthCode { get; set; }
    public int? HealthCodeId { get; set; }
}