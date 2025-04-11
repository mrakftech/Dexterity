using Domain.Entities.Appointments;

namespace Domain.Entities.Settings.Clinic
{
    public class ClinicSite
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
