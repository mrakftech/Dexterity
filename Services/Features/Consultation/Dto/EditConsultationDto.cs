using Services.State;

namespace Services.Features.Consultation.Dto
{
    public class EditConsultationDto
    {
        public DateTime ConsultationDate { get; set; } 

        public string ConsultationType { get; set; } 
        public string ConsultationClass { get; set; } 
        public string Pomr { get; set; }
        public Guid ClinicSiteId { get; set; }

        public string PatientName { get; set; } = ApplicationState.SelectedPatientName;
        public string DoctorName { get; set; } = ApplicationState.CurrentUser.Name;
    }
}
