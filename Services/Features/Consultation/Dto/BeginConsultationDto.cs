using Services.State;

namespace Services.Features.Consultation.Dto;

public class BeginConsultationDto
{
    public DateTime ConsultationDate { get; set; } = DateTime.Now;

    public string ConsultationType { get; set; } = "General";
    public string ConsultationClass { get; set; } = "General";
    public string Pomr { get; set; }
    public Guid ClinicSiteId { get; set; }

    public string PatientName { get; set; } = ApplicationState.SelectedPatientName;
    public string DoctorName { get; set; } = ApplicationState.CurrentUser.Name;
}