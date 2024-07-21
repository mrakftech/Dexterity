using Services.Features.UserAccounts.Dtos.User;

namespace Services.State;

public static class ApplicationState
{
    public static LoginResponseDto CurrentUser { get; set; }
    public static bool IsLoggedIn { get; set; }
    public static string MeetingName { get; set; }
}