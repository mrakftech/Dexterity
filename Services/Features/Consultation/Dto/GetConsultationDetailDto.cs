using Services.Features.Consultation.Dto.Notes;

namespace Services.Features.Consultation.Dto;

public class GetConsultationDetailDto
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Type { get; set; }
    public string Hcp { get; set; }
    public bool  IsFinish { get; set; }

    public List<ConsultationNoteDto> ActiveDiagnosisNotes { get; set; }
    public List<ConsultationNoteDto> PastHistoryNotes { get; set; }
}