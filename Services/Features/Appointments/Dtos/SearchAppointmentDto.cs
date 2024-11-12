namespace Services.Features.Appointments.Dtos
{
    public class SearchAppointmentDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public string Status { get; set; }
        public string PatientName { get; set; }
        public string DateOfBirth { get; set; }
    }
}
