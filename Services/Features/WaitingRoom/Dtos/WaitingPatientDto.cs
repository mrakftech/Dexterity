namespace Services.Features.WaitingRoom.Dtos;

public class WaitingPatientDto
{
    public int AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public string PatientName { get; set; }
    public string AppointmentStatus { get; set; }
}