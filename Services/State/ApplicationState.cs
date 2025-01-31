using Services.Features.Consultation.Dto;
using Services.Features.PatientManagement.Dtos.Details;
using Services.Features.UserAccounts.Dtos.User;

namespace Services.State;

public static class ApplicationState
{
    public static class SelectedPatient
    {
        public static Guid PatientId { get; set; }
        public static string PatientName { get; set; }
        public static PatientSummaryDto PatientSummary { get; set; }
    }

    public static class SelectedConsultation
    {
        public static GetConsultationDetailDto Detail { get; set; }
        public static int Id { get; set; }
    }

    public static class Auth
    {
        public static LoginResponseDto CurrentUser { get; set; }
        public static bool IsLoggedIn { get; set; }
    }

    public static class Telehealth
    {
        public static string MeetingName { get; set; }
        public static string MeetingLink { get; set; }
    }

}