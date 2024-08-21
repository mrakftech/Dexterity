namespace Services.Features.Appointments.Dtos;

public class AppointmentHistoryDto
{
    public DateTime StartTime { get; set; } 
    public string PatientName { get; set; }
    public string Hcp { get; set; }
    public string Duration { get; set; }
    public string Type { get; set; }
}