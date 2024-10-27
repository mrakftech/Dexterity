using Services.Features.PatientManagement.Dtos.Details;
using Services.Features.UserAccounts.Dtos.User;

namespace Services.State;

public static class ApplicationState
{
    public static LoginResponseDto CurrentUser { get; set; }
    public static bool IsLoggedIn { get; set; }

    public static Guid SelectedPatientId { get; set; }
    public static int SelectedConsultationId { get; set; }
    public static string SelectedPatientName { get; set; }
    public static PatientSummaryDto SelectedPatientSummary { get; set; }


    public static class Telehealth
    {
        public static string MeetingName { get; set; }
        public static string MeetingLink { get; set; }
    }

}