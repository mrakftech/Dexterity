using Domain.Contracts;

namespace Domain.Entities.Appointments
{
    public class AppointmentType:IBaseId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool Active { get; set; }
    }
}