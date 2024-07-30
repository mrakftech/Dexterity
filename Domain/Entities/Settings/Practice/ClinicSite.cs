using Domain.Entities.Appointments;
using Domain.Entities.PatientManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Settings.Practice
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
