namespace Services.Features.Appointments.Dtos
{
    public class AppointmentSlotDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public Guid HcpId { get; set; }

        
    }
}
