
using Domain.Entities.Settings.Consultation;

namespace Services.Features.Consultation.Dto.Notes;

public class ConsultationNoteDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } 
    public bool IsPastHistory { get; set; }
    public bool IsFamilyHistory { get; set; }
    public bool IsActiveCondition { get; set; }
    public bool IsScoialHistory { get; set; }
    public bool IsPrivate { get; set; }
    public string Notes { get; set; }
    public string DoctorName { get; set; }
    public int ConsultationDetailId { get; set; }
    
    public HealthCode HealthCode { get; set; }
}