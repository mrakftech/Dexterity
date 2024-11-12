namespace Services.Features.Appointments.Dtos
{
    public class AppointmentSlotDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }

        
    }
}
