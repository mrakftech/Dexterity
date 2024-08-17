using Domain.Entities.Settings.Hospital;

namespace Domain.Entities.PatientManagement.Extra
{
    public class PatientHospital
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
    }
}
