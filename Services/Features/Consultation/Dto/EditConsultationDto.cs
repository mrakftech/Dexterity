using Services.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Features.Consultation.Dto
{
    public class EditConsultationDto
    {
        public DateTime ConsultationDate { get; set; } 

        public string ConsultationType { get; set; } 
        public string ConsultationClass { get; set; } 
        public string Pomr { get; set; }
        public int ClinicSiteId { get; set; }

        public string PatientName { get; set; } = ApplicationState.SelectedPatientName;
        public string DoctorName { get; set; } = ApplicationState.CurrentUser.Name;
    }
}
