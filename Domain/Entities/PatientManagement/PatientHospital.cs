using Domain.Entities.Settings.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PatientManagement
{
    public class PatientHospital
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }
    }
}
