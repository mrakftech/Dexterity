using System.ComponentModel.DataAnnotations;
using Services.Features.PatientManagement.Dtos.Options;
using Shared.Attributes;

namespace Services.Features.PatientManagement.Dtos.Details
{
    public class PatientHospitalDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select hospital")]
        public int HospitalId { get; set; }

        public HospitalDto Hospital { get; set; }
        public Guid PatientId { get; set; }
    }
}