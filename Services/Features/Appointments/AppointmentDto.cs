namespace Services.Features.Appointments;

public class AppointmentDto
{
    public string Title { get; set; }

    public string Color { get; set; }

    public int Duration { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid PatientId { get; set; }
}