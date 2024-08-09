namespace Domain.Entities.Appointments
{
    public class AppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool Active { get; set; }
    }
}
