using Domain.Entities.Appointments;

namespace Domain.Entities.Settings.Clinic
{
    public class ClinicSite
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Settings.Clinic.Clinic Clinic { get; set; }
        public int ClinicId { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
