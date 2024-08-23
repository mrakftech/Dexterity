using Domain.Entities.PatientManagement.Options;

namespace Domain.Entities.PatientManagement.Extra
{
    public class PatientHospital
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
    }
}
