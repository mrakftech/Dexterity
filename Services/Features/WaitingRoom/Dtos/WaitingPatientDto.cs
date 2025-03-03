namespace Services.Features.WaitingRoom.Dtos;

public class WaitingPatientDto
{
    public string PatientName { get; set; }
    public TimeSpan Time { get; set; }
    public string PatientType { get; set; }
    public string AppointmentType { get; set; }
    public string Hcp { get; set; }
    public string Status { get; set; }
    public string PersonalBalance { get; set; }
    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public Guid ConsultationId { get; set; }

}