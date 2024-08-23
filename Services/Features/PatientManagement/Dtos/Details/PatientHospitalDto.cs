using Services.Features.PatientManagement.Dtos.Options;

namespace Services.Features.PatientManagement.Dtos.Details
{
    public class PatientHospitalDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int HospitalId { get; set; }
        public HospitalDto Hospital { get; set; }
        public Guid PatientId { get; set; }
    }
}
