using System.ComponentModel.DataAnnotations;
using Shared.Constants.Module.Consultation;

namespace Services.Features.Consultation.Dto.Notes;

public class UpsertConsultationNoteDto
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string Status { get; set; } = NotesStatus.None;
    public bool IsPastHistory { get; set; }
    public bool IsFamilyHistory { get; set; }
    public bool IsActiveCondition { get; set; }
    public bool IsSocialHistory { get; set; }
    public bool IsPrivate { get; set; }
    [Required] public string Notes { get; set; }
    public int ConsultationDetailId { get; set; }


    [Range(1, int.MaxValue,ErrorMessage = "Please Select code")]
    public int HealthCodeId { get; set; }
}