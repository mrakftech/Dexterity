using Services.Features.Appointments.Dtos;
using Services.Features.Consultation.Dto;
using Services.Features.PatientManagement.Dtos.Details;
using Services.Features.UserAccounts.Dtos.User;

namespace Services.State;

public static class ApplicationState
{
    public static class SelectedAppointment
    {
        public static Guid Id { get; set; }
        public static AppointmentDto Appointment { get; set; }
    }

    public static class Patient
    {
        private static Guid Id { get; set; } = Guid.Empty;
        public static string Name { get; set; }
        public static PatientSummaryDto Summary { get; set; }

        public static void ClearPatient()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Summary = new PatientSummaryDto();
        }
        public static void SetPatient(Guid patientId,PatientSummaryDto summary)
        {
            Id = patientId;
            Name = summary.Name;
            Summary = summary;
        }

        public static void SetPatientId(Guid patientId,string name=null)
        {
            Id = patientId;
            Name = name ?? string.Empty;
        }
        
        public static Guid GetSelectPatientId()
        {
            return Id;
        }
        public static string GetSelectPatientName()
        {
            return Name;
        }
        public static bool IsPatientSelected()
        {
            return Id != Guid.Empty;
        }
    }

    public static class SelectedConsultation
    {
        public static GetConsultationDetailDto Detail { get; set; }
        public static Guid Id { get; set; }
    }

    public static class Auth
    {
        public static LoginResponseDto CurrentUser { get; set; }
        public static bool IsLoggedIn { get; set; }
        public static Guid SelectedModuleId { get; set; }
        public static List<int> SelectedClinics { get; set; }

        public static void SetClinicIds(List<int> clinicIds)
        {
            SelectedClinics = clinicIds;
        }
    }

    public static class Telehealth
    {
        public static string MeetingName { get; set; }
        public static string MeetingLink { get; set; }
    }
}