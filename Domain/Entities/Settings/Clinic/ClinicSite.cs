using Domain.Entities.Appointments;

namespace Domain.Entities.Settings.Hospital
{
    public class ClinicSite
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
