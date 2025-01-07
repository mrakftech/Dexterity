namespace Domain.Entities.Appointments;

public class AppointmentSlot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartTime { get; set; }
    public bool IsAvailable { get; set; }

    public Guid HcpId { get; set; }
}