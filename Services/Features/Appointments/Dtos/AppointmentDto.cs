namespace Services.Features.Appointments.Dtos;

public class AppointmentDto
{
    public string Title { get; set; }
    public string Color { get; set; }
    public int Duration { get; set; }
    public string Notes { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public DateTime EndDate { get; set; }
    
    public Guid PatientId { get; set; }
    public Guid HcpId { get; set; }
}