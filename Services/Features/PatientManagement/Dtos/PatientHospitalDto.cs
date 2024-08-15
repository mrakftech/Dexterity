using Domain.Entities.Settings.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Features.Settings.Dtos;

namespace Services.Features.PatientManagement.Dtos
{
    public class PatientHospitalDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public int ClinicId { get; set; }
        public ClinicDto Clinic { get; set; }
        public Guid PatientId { get; set; }
    }
}
