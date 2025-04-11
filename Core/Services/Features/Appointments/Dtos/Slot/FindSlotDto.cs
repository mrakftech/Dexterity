namespace Services.Features.Appointments.Dtos.Slot;

public class FindSlotDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
}